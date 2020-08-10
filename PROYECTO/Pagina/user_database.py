#import pyodbc
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
    query="select id_Tipo_usuario,clave_usuario,estado_usuario from USUARIO where id_usuario='"+usuario+"'"
    Cursor = Connect().cursor()
    Cursor.execute(query)
    for x in Cursor:
        if(str(x[2]).upper()!='A'):
            return "EE:Usuario Inactivo"
        else:
            clave_d=Cursor.execute("Exec ValidaPass '"+usuario+"','"+clave+"'")
            if(clave_d!=clave):
                return "EE:Clave Incorrecta"
            else:
                return "00:"+str(x[0])
    return "EE:No Existe el usuario"
def Inserta_Usuario(usuario,nombre,email,clave,tipo,sexo):
    #query='Exec IUsuario ''+str(usuario)+'',''+str(nombre)+'','+tipo+',''+str(clave)+'',''+str(sexo)+'',''+str(email)+'''
    args=(usuario,nombre,tipo,clave,sexo,email)
    try:
        #query='''
        #Exec IUsuario @ii_usuario={{usuario}},
        #@ii_nombre={{nombre}},@ii_id_Tipo_u={{tipo}},
        #@ii_passw={{clave}},@ii_sexo={{sexo}},@ii_email={{email}}
        #'''
        #params = {
        #    '@ii_usuario': str(usuario),
        #    '@ii_nombre': str(nombre),
        #    '@ii_id_Tipo_u': tipo,
        #    '@ii_passw': str(clave),
        #    '@ii_sexo': str(sexo),
        #    '@ii_email': str(email),
        #}
        #sql="Exec IUsuario ?,?,?,?,?,? "
        cliente='1'
        sql="Exec IUsuario '"+usuario+"','"+nombre+"',"+tipo+",'"+clave+"','"+sexo+"','"+email+"'"
        Cursor = Connect().cursor()
        Cursor.execute(sql)
        for x in Cursor:
            ini=x[0:2]
            msj=x[3:]
            if ini=="EE":
                Cursor.close()
                return msj
            else:
                Cursor.close()
                return "00:Usuario Creado"

    except Exception as ex:
        return "EE:No se pudo crear Cuenta"+ex
