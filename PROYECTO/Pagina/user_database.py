#import pyodbc
import io
import tkinter

import numpy as np
import pymssql
import base64
from PIL import Image
from io import BytesIO
#import cv2
def Connect():
    conn = pymssql.connect(server='173.249.57.62', user='ElFinal',
                           password='12345', database='db_ElFinal')
    #conn = pymssql.connect(server='QJM_SUGEIRI', user='sa',
    #                        password='971223', database='db_ElFinal')
    return conn
def Valida_Usuario(usuario,clave):
    conn = Connect()
    query="select id_Tipo_usuario,estado_usuario from USUARIO where id_usuario='"+usuario+"'"
    Cursor = conn.cursor()
    Cursor.execute(query)
    row = Cursor.fetchone()
    estado=row[1]
    tipo_user=row[0]
    if(estado[0].upper()!='A'):
        return "EE:Usuario Inactivo"
    else:
        Cursor_02 = conn.cursor()
        Cursor_02.execute("Exec ValidaPass '"+usuario+"','"+clave+"'")
        row_02 = str(Cursor_02.fetchone()).split('|')
        Resp = row_02[1].split(':')
        tipo=Resp[0]
        msj = Resp[1]
        if(tipo=='EE'):
            return "EE:Clave Incorrecta"
        else:
            return "00:"+ str(msj) + "|"+ str(tipo_user)
          #return "00:" + msj
    return "EE:No Existe el usuario"
def Inserta_Usuario(usuario,nombre,email,clave,tipo,sexo):
    try:
        conn=Connect()

        sql = "Exec Valida_Correo '" + email + "'"
        Cursor_01 = conn.cursor()
        Cursor_01.execute(sql)
        for x in Cursor_01:
            ini = str(x)[2:4]
            msj = str(x)[5:]
            if ini == "EE":
                Cursor_01.close()
                conn.close()
                return msj
        conn.commit()

        sql="Exec ITercero '"+nombre+"','"+sexo+"','"+email+"'"
        Cursor_02 = conn.cursor()
        Cursor_02.execute(sql)
        row = str(Cursor_02.fetchone()).split('|')
        conn.commit()
        Resp=row[1].split(':')
        msj = Resp[1]
        if Resp[0].upper()=='EE':
            Cursor_01.close()
            conn.close()
            return msj

        codido_t=msj
        sql="Exec IUsuario "+codido_t+",'"+usuario+"',"+tipo+",'"+clave+"'"
        Cursor_03 = conn.cursor()
        Cursor_03.execute(sql)
        row_03 = str(Cursor_03.fetchone()).split('|')
        conn.commit()
        R = row_03[1].split(':')
        msj = R[1]
        if R[0].upper() == 'EE':
            Cursor_03.close()
            conn.close()
            return msj
        else:
            Cursor_03.close()
            conn.close()
            return "00:Usuario Creado"

    except Exception as ex:
        return "EE:No se pudo crear Cuenta"+ex
def Consulta_Solo_CategoriaArt():
    query = "select id_cat_articulo,descr_cat_articulo from categoria_articulo where estado_cat_articulo='A'"
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista=[]
    dict={}
    for x in Cursor:
        dict={'cat':x[0],'descr':x[1]}
        lista.append(dict)
    conn.close()
    return lista
def Consulta_CategoriaArt():
    query = "select id_cat_articulo,descr_cat_articulo from categoria_articulo where estado_cat_articulo='A'"
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista=[]
    dict={}
    for x in Cursor:
        grupos=Consulta_Grupos_deCat(x[0])
        dict={'cat':x[0],'descr':x[1],'grupos':grupos}
        lista.append(dict)
    conn.close()
    return lista
def Consulta_CategoriaArt_Xart():
    query = "select id_cat_articulo,descr_cat_articulo from categoria_articulo where estado_cat_articulo='A'"
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista=[]
    dict={}
    for x in Cursor:
        articulos=Busca_Articulo_XCat(x[0])
        dict={'cat':x[0],'descr':x[1],'articulos':articulos}
        lista.append(dict)
    conn.close()
    return lista
def Consulta_TotalEnCarro(usuario):
    query = "select count(*) from Carro_compra where id_usuario_cc='"+usuario+"'"
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    cant=Cursor.fetchone()
    conn.close()
    return cant
def Busca_Articulo_XCat(cat):
    query = " exec Busca_Articulo_XCat "+str(cat)
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista_1=[]
    dict_1={}
    for x in Cursor:
        dict_1 = {'articulo': x[0],
                  'descr': x[1],
                  'cat': x[2],
                  'grupo': x[3],
                  'tipo': x[4],
                  'inv': x[5],
                  'foto': x[6]}

        lista_1.append(dict_1)
    conn.close()
    return lista_1
def Consulta_Grupos_deCat(cat):
    query = " exec Busca_Grupo_xCat "+str(cat)
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista_1=[]
    dict_1={}
    for x in Cursor:
        tipos=Consulta_Tipos_deGrupo(x[1])
        dict_1={'cat':x[0],'grupo':x[1],'descr':x[2],'tipos':tipos}
        lista_1.append(dict_1)
    conn.close()
    return lista_1
def Consulta_Grupos_xCat(cat):
    query = " exec Busca_Grupo_xCat "+str(cat)
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista_1=[]
    dict_1={}
    for x in Cursor:
        dict_1={'cat':x[0],'grupo':x[1],'descr':x[2]}
        lista_1.append(dict_1)
    conn.close()
    return lista_1

def Consulta_Grupos():
    query = "  select * from GRUPO_ARTICULO where estado_g_articulo='A' "
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista_1=[]
    dict_1={}
    for x in Cursor:
        dict_1={'grupo':x[0],'descr':x[1]}
        lista_1.append(dict_1)
    conn.close()
    return lista_1

def Consulta_TipoArt():
    query = "  select * from TIPO_ARTICULO where estado_t_articulo='A' "
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista_1=[]
    dict_1={}
    for x in Cursor:
        dict_1={'tipo':x[0],'descr':x[1]}
        lista_1.append(dict_1)
    conn.close()
    return lista_1

def Consulta_Tipos_deGrupo(grupo):
    query = " exec Busca_Tipo_xGrupo "+str(grupo)
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista=[]
    dict={}
    for x in Cursor:
        dict={'grupo':x[0],'tipo':x[1],'descr':x[2]}
        lista.append(dict)
    conn.close()
    return lista

def Consulta_TipoReceta():
    query = " select id_t_receta,UPPER(descr_t_receta) from tipo_receta where estado_t_receta='A' "
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista=[]
    dict={}
    for x in Cursor:
        receta=Consulta_Receta(x[0])
        dict={'tipo':str(x[0]),'descr':x[1],'recetas':receta}
        lista.append(dict)
    conn.close()
    return lista
def Consulta_Receta(tipo):
    query = " exec Busca_Receta_XTipo "+str(tipo)
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista=[]
    dict={}
    for x in Cursor:
        formula=Consulta_Formula_Receta(x[0])
        dict={'tipo':str(tipo),'receta':x[0],'descr':x[1],'foto':x[2],'porcion':x[3],'tiempo':x[4],'formula':formula}
        lista.append(dict)
    conn.close()
    return lista
def Base64_To_Image(dato,filename):
    im = Image.open(BytesIO(base64.b64decode(dato)))
    return im
def Consulta_Formula_Receta(receta):
    query = " exec Busca_Formula_Receta "+str(receta)
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista=[]
    dict={}
    for x in Cursor:
        sust=False
        if str(x[5]).upper() =='X':
            sust=True
        dict={'articulo':x[0],
              'descr':x[1],
              'unidad':x[2],
              'descr_unidad':x[3],
              'cant':x[4],
              'sustituir':sust,
              'categoria':x[6],
              'grupo': x[7],
              'descr_grupo': x[8],
              'tipo': x[9],
              'descr_tipo': x[10],
              'inv': x[11],
              'foto': x[12]}
        lista.append(dict)
    conn.close()

    return lista
def Consulta_Formula_Receta_XUsuario(usuario,receta):
    query = " exec Busca_Formula_Receta_XUsuario 'sugeiri','3'"#+usuario+"',"+str(receta)
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista=[]
    dict={}
    for x in Cursor:
        sust = False
        if str(x[5]).upper() == 'X':
            sust = True
        dict = {'articulo': x[0],
                'descr': x[1],
                'unidad': x[2],
                'descr_unidad': x[3],
                'cant': x[4],
                'sustituir': sust,
                'categoria': x[6],
                'grupo': x[7],
                'descr_grupo': x[8],
                'tipo': x[9],
                'descr_tipo': x[10],
                'inv': x[11],
                'foto': x[12]}
        lista.append(dict)
    conn.close()
    return lista
def Inserta_Carrito(usuario,datos):
    spl=str(datos).split('|')
    try:
        conn=Connect()
        for spl_2 in spl:
            spl_3 = str(spl_2).split(',')
            receta = spl_3[0]
            if receta !='':
                art = spl_3[1]
                cant=spl_3[2]
                valor = spl_3[3]
                if Consulta_ExisteSust_XArt(usuario, receta,art):
                    sql = "Exec ICarrito_esp '" + usuario + "'," + receta + "," + art + "," + cant + "," + valor + ""
                else:
                    sql="Exec ICarrito '"+usuario+"',"+receta+","+art+","+cant+","+valor+""
                Cursor_02 = conn.cursor()
                Cursor_02.execute(sql)
                row = str(Cursor_02.fetchone()).split('|')
                Resp=row[1].split(':')
                msj = Resp[1]
                if Resp[0].upper()=='EE':
                    Cursor_02.close()
                    conn.close()
                    return msj
        Cursor_02.close()
        conn.commit()
        conn.close()
        return "00:Insertado"
    except Exception as ex:
        return "EE:No se pudo Agregar Productos al Carrito"+ex
def Consulta_Carrito(usuario):
    query = " exec Consulta_Carro "+str(usuario)
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista=[]
    dict={}
    for x in Cursor:
        dict={'articulo':x[1],
              'descr':x[2],
              'foto': x[3],
              'cant':x[4],
              'valor':x[5],
              'monto':x[6]}
        lista.append(dict)
    conn.close()
    return lista
def Actualiza_Carrito(usuario,datos):
    spl=str(datos).split('|')
    if len(spl)<=0:
        spl=datos
    try:
        conn=Connect()

        for spl_2 in spl:
            spl_3 = str(spl_2).split(',')
            art = spl_3[0]
            if art !='':
                cant=spl_3[1]
                valor = spl_3[2]
                sql="Exec UCarrito '"+usuario+"',"+art+","+cant+","+valor+""
                Cursor_02 = conn.cursor()
                Cursor_02.execute(sql)
                row = str(Cursor_02.fetchone()).split('|')
                Resp=row[1].split(':')
                msj = Resp[1]
                if Resp[0].upper()=='EE':
                    Cursor_02.close()
                    conn.close()
                    return msj
        Cursor_02.close()
        conn.commit()
        conn.close()
        return "00:Insertado"
    except Exception as ex:
        return "EE:No se pudo Agregar Productos al Carrito"+ex
def Inserta_1A_Carrito(usuario,id):
    try:
        conn=Connect()
        if id !='':
            art = id
            cant='1'
            valor = '0'
            sql="Exec IArt_Carrito '"+usuario+"',"+art+","+cant+","+valor+""
            Cursor_02 = conn.cursor()
            Cursor_02.execute(sql)
            row = str(Cursor_02.fetchone()).split('|')
            Resp=row[1].split(':')
            msj = Resp[1]
            if Resp[0].upper()=='EE':
                Cursor_02.close()
                conn.close()
                return msj
        Cursor_02.close()
        conn.commit()
        conn.close()
        return "00:Insertado"
    except Exception as ex:
        return "EE:No se pudo Agregar Productos al Carrito"+ex
def Busca_Articulo_Equivalente(art):
    query = " exec Busca_Articulo_Equivalente "+str(art)
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista_1=[]
    dict_1={}
    for x in Cursor:
        dict_1 = {'articulo': x[0],
                  'descr': x[1],
                  'cat': x[3],
                  'grupo': x[3],
                  'tipo': x[4],
                  'inv': x[5],
                  'foto': x[7]}

        lista_1.append(dict_1)
    conn.close()
    return lista_1
def Consulta_ExisteSust(usuario,receta):
    query = " exec Consulta_ExisteSust '"+usuario+"',"+str(receta)
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    row = Cursor.fetchone()
    if row[0]=="00":
        conn.close()
        return True
    else:
        conn.close()
        return False
def Consulta_ExisteSust_XArt(usuario,receta,articulo):
    query = " exec Consulta_ExisteSust_Art '"+usuario+"',"+str(receta)+","+str(articulo)
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    row = str(Cursor.fetchone())
    conn.close()
    if row=="00":
        return True
    else:
        return False

def Inserta_Sustututo(usuario,art_Ori,art_Nue,receta):

    try:
        conn=Connect()
        sql = "Exec ISustituto '" + usuario + "'," + receta + "," + art_Ori + "," + art_Nue
        Cursor_02 = conn.cursor()
        Cursor_02.execute(sql)
        row = str(Cursor_02.fetchone()).split('|')
        Resp=row[1].split(':')
        msj = Resp[1]
        if Resp[0].upper()=='EE':
            Cursor_02.close()
            conn.close()
            return msj
        Cursor_02.close()
        conn.commit()
        conn.close()
        return "00:Insertado"
    except Exception as ex:
        return "EE:No se pudo Agregar Productos al Carrito"+ex