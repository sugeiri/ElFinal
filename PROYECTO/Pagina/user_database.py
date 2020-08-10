#import pyodbc
import tkinter
import pymssql
def Connect():
    #conn = pymssql.connect('Driver={SQL Server};'
    #                      'Server=QJM_SUGEIRI;'
    #                      'Database=db_ElFinal;'
    #                      'Trusted_Connection=yes;')
    conn = pymssql.connect(server='QJM_SUGEIRI', user='sa',
                           password='971223', database='db_ElFinal')
    return conn
def Ejecuta_Consulta(query):
    Cursor=Connect().cursor()
    Cursor.execute(query)
    return Cursor
def Valida_Usuario(usuario,clave):
    conn = Connect()
    query="select id_Tipo_usuario,estado_usuario from USUARIO where id_usuario='"+usuario+"'"
    Cursor = conn.cursor()
    Cursor_02 = conn.cursor()
    Cursor.execute(query)
    row = Cursor.fetchone()
    estado=row[1]
    tip = row[0]
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
