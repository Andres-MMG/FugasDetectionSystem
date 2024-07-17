import os

def leer_archivo_con_codificacion(path, codificaciones=['windows-1252', 'latin-1', 'cp1252']):
    contenido = ''
    for codificacion in codificaciones:
        try:
            with open(path, 'r', encoding=codificacion) as archivo:
                contenido = archivo.readlines()
                break  # Sale del ciclo si la lectura fue exitosa
        except UnicodeDecodeError:
            pass  # Intenta con la siguiente codificación
    return contenido

def listar_clases_y_directorios(ruta, archivo, indent=0):
    archivos_excluidos = ['.suo', '.user', '.gitignore', 'appsettings.json', 'appsettings.Development.json']
    carpetas_excluidas = ['bin', 'obj', '.vs', '.git', 'Properties', 'Connected Services']
    extensiones_incluidas = ['.cs', '.json', '.txt']

    for elemento in os.listdir(ruta):
        path_elemento = os.path.join(ruta, elemento)
        if any(elemento == carpeta for carpeta in carpetas_excluidas) or any(elemento.endswith(ext) for ext in archivos_excluidos):
            continue

        if os.path.isdir(path_elemento):
            archivo.write('  ' * indent + ' ' + elemento + '/\n')
            listar_clases_y_directorios(path_elemento, archivo, indent + 1)
        elif any(path_elemento.endswith(ext) for ext in extensiones_incluidas):
            archivo.write('  ' * indent + ' ' + elemento + '\n')
            file_content = leer_archivo_con_codificacion(path_elemento)
            if file_content:
                archivo.write('  ' * indent + ' ' + '/*\n')
                for line in file_content:
                    archivo.write('  ' * indent + ' ' + line)
                archivo.write('  ' * indent + ' ' + '*/\n\n')
            else:
                print(f"No se pudo leer el archivo {path_elemento} con las codificaciones especificadas.")

ruta_inicial = os.getcwd()
nombre_proyecto = os.path.basename(ruta_inicial)

with open('estructura_proyecto.txt', 'w', encoding='utf-8') as archivo:  # Cambiado a utf-8
    archivo.write(nombre_proyecto + '/\n')
    listar_clases_y_directorios(ruta_inicial, archivo)
