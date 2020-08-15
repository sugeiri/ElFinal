from unicodedata import category

from flask import Flask, redirect, render_template, flash, session,request,url_for
import user_database
import requests

session = requests.Session()

app = Flask(__name__)
app.secret_key = b'_5#y2L"F4Q8z\n\xec]/'
Categoria=user_database.Consulta_Solo_CategoriaArt()
Grupos=user_database.Consulta_Grupos()
Tipos=user_database.Consulta_TipoArt()
TipoReceta = user_database.Consulta_TipoReceta()
@app.route('/')
def main_index():
    username=''
    cant=0
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant=user_database.Consulta_TotalEnCarro(username)
        cant = cant[0]
    return render_template('index.html',usuario=username,carrito=cant,Categoria=Categoria)
@app.route('/shop')
def shop():
    username = ''
    cant=0
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
        cant=cant[0]
    Articulos=user_database.Busca_Articulo_XCat('')
    return render_template('shop.html',
                           usuario=username,carrito=cant,
                           Categoria=Categoria,
                           categoria=0,
                           Grupos=Grupos,
                           Tipos=Tipos,
                           Articulos=Articulos)
@app.route('/shop_xcat/<id>')
def shop_xcat(id):
    username = ''
    cant=0
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
        cant=cant[0]
    cat=''
    cat=id
    Articulos = user_database.Busca_Articulo_XCat(cat)
    Grupos = user_database.Consulta_Grupos_xCat(cat)
    return render_template('shop.html',
                           usuario=username,carrito=cant,
                           Categoria=Categoria,
                           categoria=0,
                           Grupos=Grupos,
                           Tipos=Tipos,
                           Articulos=Articulos)

@app.route('/shop-cart')
def shopcart():
    username = ''
    carro=''
    importe=0
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
        cant = cant[0]
        carro = user_database.Consulta_Carrito(username)
        for x in carro:
            importe+=x['monto']
        return render_template('shop-cart.html',
                               usuario=username,
                               carrito=cant,
                               carro=carro,
                               total=importe,
                               Categoria=Categoria)
    else:
        return redirect("/Login", code=302)
    return 'ok'

@app.route('/Login')
def login():
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        return redirect("/", code=302)
    return render_template('login.html')

@app.route('/IniciarSesion',  methods=['POST'])
def IniciarSesion():
    if request.method == 'POST':
        usuario = request.form['username']
        clave = request.form['password']
        resultado = user_database.Valida_Usuario(usuario, clave)
        Error = str(resultado[0:2]).upper()
        tipo = str(resultado[3:])
        if Error != "EE":
            session.auth = (usuario, clave)
            session.cookies={'username': usuario}
            return redirect("/", code=302)
        elif Error == "EE":
            flash(tipo)
            return redirect(request.url)
    else:
        pass
@app.route("/sign-out")
def sign_out():
    cant=0
    session.cookies.pop("username", None)
    return redirect("/", code=302)

@app.route('/Registro', methods=['POST'])
def Registro():
    if request.method == 'POST':
        usuario= request.form['usernamesignup']
        nombre = request.form['nombresignup']
        email= request.form['emailsignup']
        clave= request.form['passwordsignup']
        confirmacion= request.form['passwordsignup_confirm']
        sexo = request.form['sexosignup']
        tipo = request.form['tiposignup']
        if clave!=confirmacion:
            flash('Las Claves no Coinciden')
            return render_template('login.html')
            pass
        else:
            resultado = user_database.Inserta_Usuario(usuario,nombre,email,clave,tipo,sexo)
            Error = resultado[0:2].upper()
            tipo = str(resultado[3:])
            if Error != "EE":
                x = tipo + '|' + usuario
                return redirect("/", code=302)
            elif Error == "EE":
                flash(tipo)
                return render_template('success.html', usuario=Error + ' ' + tipo)
    else:
        pass

@app.route("/categoria/<id>")
def categoria(id):
    clave = id
    username = ''
    cant = 0
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
    return redirect("/shop", code=302)
@app.route("/recetas")
def receta():
    username = ''
    cant = 0
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
        cant = cant[0]
    return render_template('recetas.html',
                           carrito=cant,
                           usuario=username,
                           tipo_receta=TipoReceta,
                           Categoria=Categoria,
                           )
@app.route("/det_receta/<id>")
def receta_det(id):
    username = ''
    cant = 0
    Lreceta=[]
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
        cant = cant[0]
    for tipo in TipoReceta:
        for receta in tipo['recetas']:
            if str(receta['receta'])==str(id):
                Lreceta=receta
                break

    return render_template('recetas_det.html',
                           carrito=cant,
                           usuario=username,
                           receta=Lreceta,
                           Categoria=Categoria)

# @app.route('/prueba')
# def prueba():
#     username = ''
#     cant = 0
#     if 'username' in session.cookies:
#         username = session.cookies.get('username')
#         cant = user_database.Consulta_TotalEnCarro(username)
#         cant = cant[0]
#     return render_template('prueba.html',carrito=cant,usuario=username,tipo_receta=TipoReceta)
@app.route('/agregaCarrito', methods=['POST'])
def agregaCarrito():
    username = ''
    cant = 0
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
        cant = cant[0]
    if request.method == 'POST':
        Datos= request.form['Datos']
        resultado = user_database.Inserta_Carrito(username, Datos )
        Error = resultado[0:2].upper()
        tipo = str(resultado[3:])
    carro= user_database.Consulta_Carrito(username)
    importe=0
    for x in carro:
        importe+=x['monto']
    return redirect("/shop-cart", code=302)
@app.route('/agregaCarrito2', methods=['POST'])
def agregaCarrito2():
    username = ''
    if 'username' in session.cookies:
        username = session.cookies.get('username')
    if request.method == 'POST':
        Datos= request.form['Datos2']
        resultado = user_database.Inserta_Carrito(username, Datos )
        Error = resultado[0:2].upper()
        tipo = str(resultado[3:])
    return redirect("/shop-cart", code=302)
@app.route('/agrega_Art/<id>')
def agrega_Art(id):
    username = ''
    art=id
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
        cant = cant[0]
    resultado = user_database.Inserta_1A_Carrito(username, art )
    return redirect("/shop-cart", code=302)
@app.route('/Act_Carrito', methods=['POST'])
def Act_Carrito():
    username = ''
    cant = 0
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
        cant = cant[0]
    if request.method == 'POST':
        Datos= request.form['Datos']
        resultado = user_database.Actualiza_Carrito(username, Datos )
        Error = resultado[0:2].upper()
        tipo = str(resultado[3:])
    carro= user_database.Consulta_Carrito(username)
    importe=0
    for x in carro:
        importe+=x['monto']
    return redirect("/shop-cart", code=302)
# @app.route('/SustituirP/<id>')
# def SustituirP(id):
#     username = ''
#     cant = 0
#     arts=''
#     rec=''
#     arts=id
#     if 'username' in session.cookies:
#         username = session.cookies.get('username')
#         cant = user_database.Consulta_TotalEnCarro(username)
#         cant = cant[0]
#         sub=''
#         sub=str(arts).split('.')
#         arts=sub[1]
#         rec=sub[0]
#         resultado = user_database.Busca_Articulo_Equivalente(arts)
#     else:
#         return redirect("/Login", code=302)
#     return render_template('Equivalentes.html',
#                             usuario=username, carrito=cant,
#                             Articulos=resultado,
#                             Arti_Antes=arts,
#                             Receta=rec)
#
# @app.route('/AgregaSust/<id>')
# def AgregaSust(id):
#     art=''
#     art=id
#     sub = str(art).split('.')
#     arts = {'Art_Antes':sub[0],'Art_Nuevo':sub[1]}
#     ArtSus.append(arts)
#     return redirect('/det_receta/'+sub[2],code=302)
if __name__ == '__main__':
    app.debug = True
    app.run()
