from unicodedata import category

from flask import Flask, redirect, render_template, flash, session,request,url_for
import user_database
import requests

session = requests.Session()

app = Flask(__name__)
app.secret_key = b'_5#y2L"F4Q8z\n\xec]/'
categoria_Art=user_database.Consulta_CategoriaArt()
TipoReceta=user_database.Consulta_TipoReceta()
@app.route('/')
def main_index():
    username=''
    cant=0
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant=user_database.Consulta_TotalEnCarro(username)
    return render_template('index.html',usuario=username,carrito=cant)
@app.route('/shop')
def shop():
    username = ''
    cant=0
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
    return render_template('shop.html',categoria_Art=categoria_Art,usuario=username,carrito=cant,categoria=0)
@app.route('/shop-cart')
def shopcart():
    username = ''
    if 'username' in session.cookies:
        username = session.cookies.get('username')
    return render_template('shop-cart.html',usuario=username)

@app.route('/Login')
def login():
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
        return render_template('index.html',usuario=username,carrito=cant)
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
            cant = user_database.Consulta_TotalEnCarro(usuario)
            return render_template('index.html', usuario=usuario,carrito=cant)
        elif Error == "EE":
            flash(tipo)
            return redirect(request.url)
    else:
        pass
@app.route("/sign-out")
def sign_out():
    cant=0
    session.cookies.pop("username", None)
    return render_template('index.html', usuario='',carrito=0)

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
                return render_template('login.html',carrito=0)
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
    for cat in categoria_Art:
        if str(cat.get('cat')) == id:
            grupo=cat
            break
    cant = user_database.Consulta_TotalEnCarro(username)
    return render_template('shop.html',categoria=id,carrito=cant,usuario=username,categoria_Art=grupo)
@app.route("/recetas")
def receta():
    username = ''
    cant = 0
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
    return render_template('recetas.html',carrito=cant,usuario=username,tipo_receta=TipoReceta)
@app.route("/det_receta")
def receta_det():
    username = ''
    cant = 0
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        cant = user_database.Consulta_TotalEnCarro(username)
    return render_template('recetas.html',carrito=cant,usuario=username,tipo_receta=TipoReceta)

if __name__ == '__main__':
    app.debug = True
    app.run()
