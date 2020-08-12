#import pyodbc
import tkinter
import pymssql
import base64
def Connect():
    #conn = pymssql.connect(server='173.249.57.62', user='ElFinal',
    #                       password='12345', database='db_ElFinal')
    conn = pymssql.connect(server='QJM_SUGEIRI', user='ElFinal',
                           password='12345', database='db_ElFinal')
    return conn
def Valida_Usuario(usuario,clave):
    conn = Connect()
    query="select id_Tipo_usuario,estado_usuario from USUARIO where id_usuario='"+usuario+"'"
    Cursor = conn.cursor()
    Cursor_02 = conn.cursor()
    Cursor.execute(query)
    row = Cursor.fetchone()
    estado=row[1]
    if(estado[0].upper()!='A'):
        return "EE:Usuario Inactivo"
    else:
        Cursor_02.execute("Exec ValidaPass '"+usuario+"','"+clave+"'")
        row_02 = str(Cursor_02.fetchone()).split('|')
        Resp = row_02[1].split(':')
        tipo=Resp[0]
        msj = Resp[1]
        if(tipo=='EE'):
            tkinter.messagebox.showinfo(title="AVISO", message=msj)
            return "EE:Clave Incorrecta"
        else:
            return "00:"+msj
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

def Consulta_TotalEnCarro(usuario):
    query = "select count(*) from Carro_compra where id_usuario_cc='"+usuario+"'"
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    cant=Cursor.fetchone()
    conn.close()
    return cant
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
        dict={'tipo':x[0],'descr':x[1],'recetas':receta}
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
        foto_varbinary=x[2]
        encoded = base64.b64encode(foto_varbinary)
        dict={'tipo':tipo,'receta':x[0],'descr':x[1],'foto':encoded,'porcion':x[3],'tiempo':x[4],'formula':formula}
        lista.append(dict)
    conn.close()
    return lista
def Consulta_Formula_Receta(receta):
    query = " exec Busca_Formula_Receta "+str(receta)
    conn = Connect()
    Cursor = conn.cursor()
    Cursor.execute(query)
    lista=[]
    dict={}
    for x in Cursor:
        dict={'articulo':x[0],
              'descr':x[1],
              'unidad':x[2],
              'descr_unidad':x[3],
              'cant':x[4],
              'sustituir':x[5],
              'categoria':x[6],
              'grupo': x[7],
              'tipo': x[8],
              'inv': x[9],
              'foto': x[10]}
        lista.append(dict)
    conn.close()
    return lista