from unicodedata import category

from flask import Flask, redirect, render_template, flash, session,request,url_for
import user_database
import requests

session = requests.Session()

app = Flask(__name__)
app.secret_key = b'_5#y2L"F4Q8z\n\xec]/'

@app.route('/')
def main_index():
    username=''
    if 'username' in session.cookies:
        username = session.cookies.get('username')
    return render_template('index.html',usuario=username)
@app.route('/index')
def index():
    username=''
    if 'username' in session.cookies:
        username = session.cookies.get('username')
    return render_template('index.html',usuario=username)
@app.route('/shop')
def shop():
    username = ''
    if 'username' in session.cookies:
        username = session.cookies.get('username')
    return render_template('shop.html',usuario=username)
@app.route('/blog')
def blog():
    username = ''
    if 'username' in session.cookies:
        username = session.cookies.get('username')
    return render_template('blog.html',usuario=username)
@app.route('/blog-details')
def blogdetails():
    username = ''
    if 'username' in session.cookies:
        username = session.cookies.get('username')
    return render_template('blog-details.html',usuario=username)
@app.route('/checkout')
def checkout():
    username = ''
    if 'username' in session.cookies:
        username = session.cookies.get('username')
    return render_template('checkout.html',usuario=username)
@app.route('/contact')
def contact():
    username = ''
    if 'username' in session.cookies:
        username = session.cookies.get('username')
    return render_template('contact.html',usuario=username)
@app.route('/product-details')
def productdetails():
    username = ''
    if 'username' in session.cookies:
        username = session.cookies.get('username')
    return render_template('product-details.html',usuario=username)
@app.route('/shop-cart')
def shopcart():
    username = ''
    if 'username' in session.cookies:
        username = session.cookies.get('username')
    return render_template('shop-cart.html',usuario=username)

@app.route('/FlaskTutorial',  methods=['POST'])
def success():
   if request.method == 'POST':
       email = request.form['id']
       query='select descr_articulo from articulo where id_articulo='+email
       consulta=user_database.Ejecuta_Consulta(query)
       for x in consulta:
           descr=x
       return render_template('success.html', id=descr)
   else:
       pass
@app.route('/Login')
def login():
    if 'username' in session.cookies:
        username = session.cookies.get('username')
        return render_template('index.html', usuario=username)
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
            return render_template('index.html', usuario=usuario)
        elif Error == "EE":
            flash(tipo)
            return redirect(request.url)
    else:
        pass
@app.route("/sign-out")
def sign_out():
    session.cookies.pop("username", None)
    return render_template('index.html', usuario='')

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
                return render_template('login.html')
            elif Error == "EE":
                flash(tipo)
                return render_template('success.html', usuario=Error + ' ' + tipo)
    else:
        pass
@app.route("/menu")
def menu():
    return render_template('menu.html')

if __name__ == '__main__':
    app.debug = True
    app.run()
