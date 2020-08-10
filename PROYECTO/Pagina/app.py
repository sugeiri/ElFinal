from unicodedata import category

from flask import Flask, request, make_response, redirect, render_template, flash, session, message_flashed, current_app,request,url_for
import user_database
from tkinter import messagebox

app = Flask(__name__)
app.secret_key = b'_5#y2L"F4Q8z\n\xec]/'

@app.route('/')
def main_index():
    return render_template('login.html')

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
    return render_template('login.html')

@app.route('/IniciarSesion',  methods=['POST'])
def IniciarSesion():
    if request.method == 'POST':
        usuario = request.form['username']
        clave = request.form['password']
        resultado=user_database.Valida_Usuario(usuario,clave)
        Error=str(resultado[0:2]).upper()
        tipo=str(resultado[3:])
        if Error!="EE":
           x=tipo+'|'+usuario
           return render_template('success.html', usuario=x)
        elif Error=="EE":
            flash(tipo)
            return render_template('login.html')
    else:
        pass


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

if __name__ == '__main__':
    app.debug = True
    app.run()
