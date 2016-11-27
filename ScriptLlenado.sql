Use MyLearnDB;
GO

INSERT INTO USUARIO_MYEMPLOYEE (NombreUsuario,Contrasena,Sal,Estado) VALUES ('MyEmployeeUser1','qwertyui','56tyfgs5','A')



INSERT INTO PAIS (Pais) VALUES('Argentina')
INSERT INTO PAIS (Pais) VALUES('Bélgica')
INSERT INTO PAIS (Pais) VALUES('Brasil')
INSERT INTO PAIS (Pais) VALUES('Canadá')
INSERT INTO PAIS (Pais) VALUES('Chile')
INSERT INTO PAIS (Pais) VALUES('Colombia')
INSERT INTO PAIS (Pais) VALUES('Costa Rica')
INSERT INTO PAIS (Pais) VALUES('España')
INSERT INTO PAIS (Pais) VALUES('Estados Unidos')
INSERT INTO PAIS (Pais) VALUES('Francia')
INSERT INTO PAIS (Pais) VALUES('Guatemala')
INSERT INTO PAIS (Pais) VALUES('México')
INSERT INTO PAIS (Pais) VALUES('Panamá')
INSERT INTO PAIS (Pais) VALUES('Portugal')
INSERT INTO PAIS (Pais) VALUES('Suiza')


EXEC SP_Insertar_Universidad 'Instituto Tecnologico de Costa Rica'
EXEC SP_Insertar_Universidad 'Universidad Nacional'
EXEC SP_Insertar_Universidad 'Universidad de Costa Rica'
EXEC SP_Insertar_Universidad 'Universidad Autónoma de Centro América'
EXEC SP_Insertar_Universidad 'Universidad Fidélitas'

EXEC SP_Insertar_Tecnologia 'SQL Server'
EXEC SP_Insertar_Tecnologia 'HTML'
EXEC SP_Insertar_Tecnologia 'C#'
EXEC SP_Insertar_Tecnologia 'Bootstrap'
EXEC SP_Insertar_Tecnologia 'AngularJs'
EXEC SP_Insertar_Tecnologia 'Python'
EXEC SP_Insertar_Tecnologia 'C'
EXEC SP_Insertar_Tecnologia 'C++'
EXEC SP_Insertar_Tecnologia 'Java'
EXEC SP_Insertar_Tecnologia 'Scheme'
EXEC SP_Insertar_Tecnologia 'Prolog'
EXEC SP_Insertar_Tecnologia 'Github'
EXEC SP_Insertar_Tecnologia 'Rust'
EXEC SP_Insertar_Tecnologia 'Visual Studio'
EXEC SP_Insertar_Tecnologia 'Auspex'
EXEC SP_Insertar_Tecnologia 'Transonic'
EXEC SP_Insertar_Tecnologia 'Omnispex'
EXEC SP_Insertar_Tecnologia 'Vox-caster'
EXEC SP_Insertar_Tecnologia 'Melta'
EXEC SP_Insertar_Tecnologia 'Skyfire'

EXEC SP_Insertar_Estudiante '1', '1234', 'gsg4aer6g4ar68g46r5g', 'Drive', 'thrj4=56d3k', 'Gabriel', 'Angelos', '09-0873-0544', 'Gabriel@gmail.com', 85748231, 'Costa Rica', 'San Jose',1,'GabrielA', 'rg38a4gr8a4r3g8a7r4g', 'Gabriel'
EXEC SP_Insertar_Estudiante '2', '1234', '4adfn98g4ar65g4ar98n', 'Drive', '45gf3=l4h53', 'Nathaniel','Garro', '02-0623-0463', 'Nathaniel@gmail.com', 89843549, 'Costa Rica', 'San Jose',2,'NathanielG', '8g34arg863a74rgarg38', 'Nathaniel'
EXEC SP_Insertar_Estudiante '3', '1234', 'gt4ar64a664a6r8g34ar', 'Drive', 'k4563=kp4j3', 'Sebastian', 'Yarrick','05-0780-0642', 'Sebastian@gmail.com', 86548943, 'Costa Rica', 'Heredia',3,'SebastianY', 'a4gr8a4r3g8a7r4g8a7r', 'Sebastian'
EXEC SP_Insertar_Estudiante '4', '1234', 'g863a74rgarg38a4gr8a', 'Drive', 'iopbg=ny878', 'Logan', 'Grimnar', '04-0521-0623', 'Logan@gmail.com', 82189432, 'Costa Rica', 'San Jose',2,  'LoganG', 'ega87hh36a47812a6gr7', 'Logan'
EXEC SP_Insertar_Estudiante '5', '1234', '4r3g8a7r4g8a7rega87h', 'Drive', '64a6r=8g34a', 'Gregor', 'Eisenhorn', '05-0645-0450', 'Gregor@gmail.com', 81652721, 'Costa Rica', 'Heredia',3, 'GregorE', '878ilo34kghj83gh7k8d', 'Gregor'
EXEC SP_Insertar_Estudiante '6', '1234', 'h36a47812a6gr78k78il', 'Drive', 'g863a=74rga', 'Ragnar', 'Blackmane', '09-0787-0460', 'Ragnar@gmail.com', 87312731, 'Costa Rica', 'San Jose', 3, 'RagnarB', '3h4ar8697u8lo74il853', 'Ragnar'
EXEC SP_Insertar_Estudiante '7', '1234', 'o34kghj83gh7k8d3h4ar', 'Drive', 'g38a4=gr8a4', 'Davian', 'Thule', '08-0978-0705', 'Davian@gmail.com', 82761273, 'Costa Rica', 'San Jose',1, 'DavianT', 'tx586h7s35h7ga863f4g', 'Davian'
EXEC SP_Insertar_Estudiante '8', '1234', '8697u8lo74il853tx586', 'Drive', '3g8a7=r4g8a', 'Alicia', 'Dominica', '07-0698-0870', 'Alicia@gmail.com', 85126514, 'Costa Rica', 'Heredia',1,'AliciaD','fjniglk5g36f45jg3x54', 'Alicia'
EXEC SP_Insertar_Estudiante '9', '1234', 'h7s35h7ga863f4gfjnig', 'Drive', 'rega8=7hh36', 'Selena', 'Agna', '03-0542-0055', 'Selena@gmail.com', 89198472, 'Costa Rica', 'San Jose',1,'SelenaA', '345yul3g6ty3d4563thr', 'Selena'
EXEC SP_Insertar_Estudiante '10', '1234', 'lk5g36f45jg3x54345yu', 'Drive', '47812=a6gr7', 'Anais', 'Kaurava','04-0028-0954', 'Anais@gmail.com', 89874289, 'Costa Rica', 'San Jose',1,'AnaisK', 'j456d3k45gf3l4h53jk4', 'Anais'
EXEC SP_Insertar_Estudiante '11', '1234', 'l3g6ty3d45thrj456d3k', 'Drive', '878il=o34kg', 'Olga', 'Karamanz', '06-0723-0455', 'Olga@gmail.com', 84791285, 'Costa Rica', 'San Jose',2, 'OlgaK', '563kp4j3uiopbgny878c', 'Olga'
EXEC SP_Insertar_Estudiante '12', '1234', '45gf3l4h53jk4563kp4j', 'Drive', 'hj83g=h7k8d', 'Katherine', 'Elysius', '06-0046-0240', 'Katherine@gmail.com', 86152783, 'Costa Rica','Heredia',3, 'KatherineE', 'r6789xs64a6r8g34arg8', 'Katherine'

EXEC SP_Insertar_Profesor '13','1234','f4gfjniglk5g36f45jg3','Drive','3g6ty=3d456','Ada','Lovelace','Ada@gmail.com',27658127,'Lunes y Miercoles 9:30 a 12:30','Costa Rica','San Jose', '1','Ada'
EXEC SP_Insertar_Profesor '14', '1234','x54345yul3g6ty3d4563','Drive','3thrj=4564a','Blaise','Pascal','Blaise@gmail.com',22935176,'Martes y Jueves 7:30 a 9:30','Costa Rica','San Jose', '1','Blaise'
EXEC SP_Insertar_Profesor '15','1234','97u8lo74il853tx586h7','Drive','6r8g3=4arg8','Carl','Sagan','Carl@gmail.com',26250687,'Miercoles y Viernes 13:00 a 15:00','Costa Rica','San Jose', '1','Carl'
EXEC SP_Insertar_Profesor '16','1234','s35h7ga863f4gfjniglk','Drive','63a74=rgarg','Heinrich','Hertz','Heinrich@gmail.com',22506892,'Miercoles y Viernes 13:00 a 15:00','Costa Rica','San Jose', '1','Heinrich'
EXEC SP_Insertar_Profesor '17','1234','5g36f45jg3x54345yul3','Drive','38a4g=r8a4r','Gottfried','Leibniz','Gottfried@gmail.com',24565424,'Lunes y Miercoles 9:30 a 12:30','Costa Rica','San Jose', '1','Gottfried'
EXEC SP_Insertar_Profesor '18','1234','g6ty3d4563thrj456d3k','Drive','3g8a7=r4g8a','Beatrix','Potter','Beatrix@gmail.com',25560462,'Miercoles y Viernes 13:00 a 15:00','Costa Rica','San Jose', '1','Beatrix'
EXEC SP_Insertar_Profesor '19','1234','853tx586h7s35h7ga863','Drive','3x543=45yul','Edwin','Hubble','Edwin@gmail.com',27946215,'Martes y Jueves 7:30 a 9:30','Costa Rica','Heredia', '2','Edwin'

EXEC SP_Insertar_Empresa '20','1234','3uiopbgny878cr6789xs','Drive','3h4ar=8697u','Ernest','Rutherford','Marte','Marte41@gmail.com',25417489,'http://warhammer40k.wikia.com/wiki/Mars','Costa Rica','San Jose','Marte41','Ernest'
EXEC SP_Insertar_Empresa '21','1234','3rer8g34arg863a74rga','Drive','8lo74=il853','Andrey','Sakharov','Lucius','Lucius18@gmail.com',22298517,'http://warhammer40k.wikia.com/wiki/Lucius','Costa Rica','San Jose','Lucius18','Andrey'
EXEC SP_Insertar_Empresa '22','1234','rg38a4gr8a4r3g8a7r4g','Drive','tx586=h7s35','Claude','Shannon','Agripinaa','Agripinaa01@gmail.com',26523798,'http://warhammer40k.wikia.com/wiki/Agripinaa','Costa Rica','Heredia','Agripinaa01','Claude'
EXEC SP_Insertar_Empresa '23','1234','8a7rega87hh36a47812a','Drive','7ga86=3f4gf','Leonard','Euler','Stygies Ocho','Stygies8@gmail.com',25173952,'http://warhammer40k.wikia.com/wiki/Stygies_VIII','Costa Rica','San Jose','Stygies8','Leonard'
EXEC SP_Insertar_Empresa '24','1234','6gr788ilo34kghj83gh7','Drive','niglk=5g36f','Michael','Faraday','Graia','Graia13@gmail.com',21761576,'http://warhammer40k.wikia.com/wiki/Graia','Costa Rica','Heredia','Graia13','Michael'
EXEC SP_Insertar_Empresa '25','1234','k8d3h4ar8697u8lo74il','Drive','niglk=5g36f','Richard','Feynman','Metalica','Metalica7@gmail.com',28247921,'http://warhammer40k.wikia.com/wiki/Metalica','Costa Rica','San Jose','Metalica7','Richard'
EXEC SP_Insertar_Empresa '26','1234','853tx586h7s35h7ga863','Drive','3x543=45yul','Rosalind','Franklin','Ryza','Ryza30@gmail.com',27946215,'http://warhammer40k.wikia.com/wiki/Ryza','Costa Rica','San Jose','Ryza30','Rosalind'

EXEC SP_Insertar_Admin '27','1234','45gf3l4h53jk4563kp4j', '', '', 'Joseph','Campos', 'Joseph'
EXEC SP_Insertar_Admin '28','1234','3uiopbgny878cr6789xs', '', '', 'Sebastian','Gonzalez', 'SebastianG'
EXEC SP_Insertar_Admin '29','1234','3re6d3k45gf3l4h53jk4', '', '','Josafat','Vargas','Josafat'
EXEC SP_Insertar_Admin '30','1234','563kp4j3uiopbgny878c', '', '', 'Giovanni','Villalobos', 'Giovanni'


EXEC SP_Insertar_Curso '13', 'Especificacion y Diseño de Software', 'CE-4101', '1', 68, '10/17/2016', 7
EXEC SP_Insertar_Curso '14', 'Bases De Datos', 'CE-3101', '1', 68, '10/17/2016', 1
EXEC SP_Insertar_Curso '14', 'Matemática General', 'MA-0101', '1', 74, '10/17/2016', 2
EXEC SP_Insertar_Curso '15', 'Introducción a la Física', 'FI-0101', '1', 64, '10/17/2016', 4
EXEC SP_Insertar_Curso '16', 'Estructuras de Datos 2', 'CE-2102', '1', 68, '10/17/2016', 3


	/*Badges - Especificacion y Diseno de Software*/
EXEC SP_Insertar_Badge 'Usabilidad', '25', '1'
EXEC SP_Insertar_Badge 'Diagramas de Diseño', '25', '1'
EXEC SP_Insertar_Badge 'Especificación de Proyectos', '25', '1'
EXEC SP_Insertar_Badge 'Patrones de Diseño', '25', '1'

	/*Badges - Bases De Datos*/
EXEC SP_Insertar_Badge 'SQL Server', '50', '2'
EXEC SP_Insertar_Badge 'Diagramas de Diseño', '25', '2'
EXEC SP_Insertar_Badge 'C#', '25', '2'

	/*Badges - Matemática General*/
EXEC SP_Insertar_Badge 'Sumas', '25', '3'
EXEC SP_Insertar_Badge 'Restas', '25', '3'
EXEC SP_Insertar_Badge 'Geometría', '25', '3'
EXEC SP_Insertar_Badge 'Lógica', '25', '3'

	/*Badges - Introduccion a la Fisica*/
EXEC SP_Insertar_Badge 'Escalares', '5', '4'
EXEC SP_Insertar_Badge 'Vectores', '10', '4'
EXEC SP_Insertar_Badge 'Movimiento', '15', '4'
EXEC SP_Insertar_Badge 'Fuerza', '20', '4'
EXEC SP_Insertar_Badge 'Energía', '25', '4'
EXEC SP_Insertar_Badge 'Torque y Rotación', '25', '4'

	/*Badges - Estructuras de Datos 2*/
EXEC SP_Insertar_Badge 'Listas', '25', '5'
EXEC SP_Insertar_Badge 'Matrices', '25', '5'
EXEC SP_Insertar_Badge 'Grafos', '25', '5'
EXEC SP_Insertar_Badge 'Arboles', '25', '5'

	/*Agregar estudiantes*/
EXEC SP_Agregar_Al_Curso '1', '1'
EXEC SP_Agregar_Al_Curso '2', '1'
EXEC SP_Agregar_Al_Curso '3', '1'
EXEC SP_Agregar_Al_Curso '4', '1'
EXEC SP_Agregar_Al_Curso '5', '1'
EXEC SP_Agregar_Al_Curso '4', '2'
EXEC SP_Agregar_Al_Curso '5', '2'
EXEC SP_Agregar_Al_Curso '6', '2'
EXEC SP_Agregar_Al_Curso '7', '2'
EXEC SP_Agregar_Al_Curso '8', '2'
EXEC SP_Agregar_Al_Curso '9', '2'
EXEC SP_Agregar_Al_Curso '1', '3'
EXEC SP_Agregar_Al_Curso '2', '3'
EXEC SP_Agregar_Al_Curso '3', '3'
EXEC SP_Agregar_Al_Curso '7', '4'
EXEC SP_Agregar_Al_Curso '8', '4'
EXEC SP_Agregar_Al_Curso '9', '4'
EXEC SP_Agregar_Al_Curso '10', '4'
EXEC SP_Agregar_Al_Curso '11', '4'
EXEC SP_Agregar_Al_Curso '12', '4'
EXEC SP_Agregar_Al_Curso '4', '5'
EXEC SP_Agregar_Al_Curso '5', '5'
EXEC SP_Agregar_Al_Curso '11', '5'
EXEC SP_Agregar_Al_Curso '12', '5'



	/*Propuestas y tecnologías*/
EXEC SP_Insertar_Propuesta_Proyecto '1', 'DigiLearn', 'La ausencia de una plataforma para trabajar en línea y obtener experiencia laboral','ofrecer un sericio a estudiantes para que puedan trabajar en cursos de su universidad y en ofertas de trabajo', '1', '10/17/2016', '11/26/2016', '', 'A', 0
EXEC SP_Asignar_Tecnologia_Proyecto '1', '1'
EXEC SP_Asignar_Tecnologia_Proyecto '1', '2'

EXEC SP_Insertar_Propuesta_Proyecto '2', 'PlanetToaster', 'La necesidad de tostar pan','ofrecer un sericio de tostadora a domicilio a los afiliados', '1', '10/19/2016', '11/26/2016', '', 'A', 0
EXEC SP_Asignar_Tecnologia_Proyecto '2', '1'
EXEC SP_Asignar_Tecnologia_Proyecto '2', '3'

EXEC SP_Insertar_Propuesta_Proyecto '3', 'Full justification', 'la preferencia de justificar el texto de manera correcta', 'un sistema que ayuda a dar formato a lectores de libros electronicos con justificacion separada por guines en vez de separacaion por espacios en blanco', '1', '10/18/2016', '11/30/2016', '', 'A', 0
EXEC SP_Asignar_Tecnologia_Proyecto '3', '6'
EXEC SP_Asignar_Tecnologia_Proyecto '3', '15'
EXEC SP_Asignar_Tecnologia_Proyecto '3', '18'

EXEC SP_Insertar_Propuesta_Proyecto '4', 'Shredder', 'Sistema para un servicio de reciclaje de papel', 'Una maquina necesita una actualizacion de interfaz y logica que mejore la eficiencia de la empresa en un 70%', '1', '10/18/2016', '11/30/2016', '', 'A', 0
EXEC SP_Asignar_Tecnologia_Proyecto '3', '13'
EXEC SP_Asignar_Tecnologia_Proyecto '3', '16'
EXEC SP_Asignar_Tecnologia_Proyecto '3', '19'

EXEC SP_Aceptar_Proyecto '1', '1', '1'

EXEC SP_Insertar_Mensaje_Proyecto'Por favor enviarme una propuesta inicial del proyecto', '', '2','Ada Lovelace'
EXEC SP_Insertar_Respuesta '2', 'Aquí adjunto la propuesta', 'https://drive.google.com/uc?export=download&id=0B54vssG6Ahg3SHk2QmprQkdmWVE','Gabriel Angelos'
EXEC SP_Insertar_Respuesta '2', 'Excelente', '','Ada Lovelace'
EXEC SP_Insertar_Mensaje_Proyecto 'Necesito que me envie el perfil de la empresa', '', '2','Gabriel Angelos'

EXEC SP_Otorgar_Badge '1', '1', 'O'

	/*Trabajos y tecnologías*/
EXEC SP_Insertar_Trabajo 'Decripción de STCs', 'Gran cantidad de informacion se encuentra en este STC, es necesario decriptarlo', '20', '11/10/2016', '12/01/2016', '','3000'
EXEC SP_Asignar_Tecnologia_Trabajo '1', '1'
EXEC SP_Asignar_Tecnologia_Trabajo '1', '2'

EXEC SP_Insertar_Trabajo 'DrPischel', 'Para ser más competitivo la farmacia DrPischel desea crear un sistema de atención en línea, donde los usuarios puedan pre-ordenar medicamentos para facilitar su recolección', '20', '10/17/2016', '11/26/2016', '', '5000'
EXEC SP_Asignar_Tecnologia_Trabajo '2', '1'
EXEC SP_Asignar_Tecnologia_Trabajo '2', '3'

EXEC SP_Insertar_Trabajo 'Lectura de Labios', 'El fin de este trabajo es reconocer frases y oraciones dichas por un rostro hablando, con o sin audio', '22', '10/16/2016', '11/30/2016', '', 100000
EXEC SP_Asignar_Tecnologia_Trabajo '3', '13'
EXEC SP_Asignar_Tecnologia_Trabajo '3', '17'

EXEC SP_Insertar_Trabajo 'Relojes galacticos', 'Necesitamos desarrolladores que ayuden a implementar los nuevos relojes galacticos en las consolas de la flota imperial', '23', '10/18/2016', '11/29/2016', '', 100000
EXEC SP_Asignar_Tecnologia_Trabajo '4', '2'
EXEC SP_Asignar_Tecnologia_Trabajo '4', '11'
EXEC SP_Asignar_Tecnologia_Trabajo '4', '15'

EXEC SP_Insertar_Trabajo 'Multi-tecnologias', 'Buscamos crear nuevas formas de tecnologias multi-. Gran oportunidad de aprender sobre las tecnologias del Imperio', '24', '10/18/2016', '11/29/2016', '', 100000
EXEC SP_Asignar_Tecnologia_Trabajo '5', '2'
EXEC SP_Asignar_Tecnologia_Trabajo '5', '11'
EXEC SP_Asignar_Tecnologia_Trabajo '5', '15'
	
	/*Propuestas*/					
EXEC SP_Insertar_Propuesta_Subasta 2, '1', 35000, 'Knowledge is power, Guard it well!' , '02/20/2018'
EXEC SP_Insertar_Propuesta_Subasta 2, '2', 55000, 'Sisters, we must go as Martyrs! We must go up in flames!' , '09/18/2019'
EXEC SP_Insertar_Propuesta_Subasta 5, '1', 95000, 'Knowledge is power, Guard it well!', '09/18/2019'
EXEC SP_Insertar_Propuesta_Subasta 3, '3', 75000, 'The Flesh is Weak!', '09/18/2019'
EXEC SP_Insertar_Propuesta_Subasta 1, '4', 37000, 'All is dust! All is dust! All is dust!', '09/18/2019'
EXEC SP_Insertar_Propuesta_Subasta 4, '5', 40000, 'Iron within! Iron Without!', '09/18/2019'
EXEC SP_Insertar_Propuesta_Subasta 5, '5', 80000, 'Iron within! Iron Without!', '09/18/2019'
EXEC SP_Insertar_Propuesta_Subasta 3, '6', 85000, 'For the Emperor!', '09/18/2019'
EXEC SP_Insertar_Propuesta_Subasta 5, '7', 73000, 'For Lupercal!', '09/18/2019'
EXEC SP_Insertar_Propuesta_Subasta 1, '8', 25000, 'There is only the Emperor!', '09/18/2019'
EXEC SP_Insertar_Propuesta_Subasta 4, '9', 46000, 'No pity! No remorse! No fear!', '09/18/2019'

EXEC SP_Aceptar_Subasta 2, '1'

EXEC SP_Insertar_Mensaje_Trabajo 'Por favor enviarme una propuesta inicial del proyecto', '', '2','Ernest Rutherford'
EXEC SP_Insertar_Respuesta '1', 'Aquí adjunto la propuesta', 'https://drive.google.com/uc?export=download&id=0B54vssG6Ahg3SHk2QmprQkdmWVE','Gabriel Angelos'
EXEC SP_Insertar_Mensaje_Trabajo 'Necesito que me envie el perfil de la empresa', '', '2','Gabriel Angelos'

EXEC SP_Insertar_Notificacion 'Felicidades! Usted ha ganado el proyecto DrPischel', '10/17/2016', '1'
EXEC SP_Insertar_Notificacion 'Felicidades! Usted ha ganado el proyecto Barbarras', '10/17/2016', '1'



/*Llenado para MyEmployee*/


EXEC SP_Insertar_Curso '13', 'TestCourse', 'TE-4101', '1', 50, '10/17/2016', 1
EXEC SP_Insertar_Curso '13', 'TestCourse', 'TE-3101', '1', 50, '10/17/2016', 5
EXEC SP_Insertar_Curso '13', 'TestCourse', 'TE-0101', '1', 50, '10/17/2016', 2
EXEC SP_Insertar_Curso '13', 'TestCourse', 'TE-0101', '1', 50, '10/17/2016', 4
EXEC SP_Insertar_Curso '13', 'TestCourse', 'TE-2102', '1', 50, '10/17/2016', 3

EXEC SP_Insertar_Badge 'BadgeMaximus', 100, 1
EXEC SP_Insertar_Badge 'BadgeMaximus', 100, 5
EXEC SP_Insertar_Badge 'BadgeMaximus', 100, 2
EXEC SP_Insertar_Badge 'BadgeMaximus', 100, 4
EXEC SP_Insertar_Badge 'BadgeMaximus', 100, 3


INSERT INTO CURSO_POR_PROFESOR (IdCurso, IdProfesor, Estado)
VALUES (6, 13, 'A')
INSERT INTO CURSO_POR_PROFESOR (IdCurso, IdProfesor, Estado)
VALUES (7, 13, 'A')
INSERT INTO CURSO_POR_PROFESOR (IdCurso, IdProfesor, Estado)
VALUES (8, 13, 'A')
INSERT INTO CURSO_POR_PROFESOR (IdCurso, IdProfesor, Estado)
VALUES (9, 13, 'A')
INSERT INTO CURSO_POR_PROFESOR (IdCurso, IdProfesor, Estado)
VALUES (10, 13, 'A')

INSERT INTO CURSO_POR_UNIVERSIDAD (IdCurso, IdUniversidad, Estado)
VALUES (6, 1, 'A')
INSERT INTO CURSO_POR_UNIVERSIDAD (IdCurso, IdUniversidad, Estado)
VALUES (7, 1, 'A')
INSERT INTO CURSO_POR_UNIVERSIDAD (IdCurso, IdUniversidad, Estado)
VALUES (8, 1, 'A')
INSERT INTO CURSO_POR_UNIVERSIDAD (IdCurso, IdUniversidad, Estado)
VALUES (9, 1, 'A')
INSERT INTO CURSO_POR_UNIVERSIDAD (IdCurso, IdUniversidad, Estado)
VALUES (10, 1, 'A')

EXEC SP_Agregar_Al_Curso '7', '6'
EXEC SP_Agregar_Al_Curso '7', '7'
EXEC SP_Agregar_Al_Curso '7', '8'
EXEC SP_Agregar_Al_Curso '7', '9'
EXEC SP_Agregar_Al_Curso '7', '10'

EXEC SP_Agregar_Al_Curso '8', '6'
EXEC SP_Agregar_Al_Curso '8', '7'
EXEC SP_Agregar_Al_Curso '8', '8'
EXEC SP_Agregar_Al_Curso '8', '9'
EXEC SP_Agregar_Al_Curso '8', '10'

UPDATE ESTUDIANTE_POR_CURSO SET Nota=50, Estado='F' WHERE IdCurso=6 AND IdEstudiante=7
UPDATE ESTUDIANTE_POR_CURSO SET Nota=80, Estado='E' WHERE IdCurso=6 AND IdEstudiante=8
UPDATE ESTUDIANTE_POR_CURSO SET Nota=70, Estado='E' WHERE IdCurso=7
UPDATE ESTUDIANTE_POR_CURSO SET Nota=65, Estado='F' WHERE IdCurso=8 AND IdEstudiante=7
UPDATE ESTUDIANTE_POR_CURSO SET Nota=95, Estado='E' WHERE IdCurso=8 AND IdEstudiante=8
UPDATE ESTUDIANTE_POR_CURSO SET Nota=48, Estado='F' WHERE IdCurso=9 AND IdEstudiante=7
UPDATE ESTUDIANTE_POR_CURSO SET Nota=57, Estado='F' WHERE IdCurso=9 AND IdEstudiante=8
UPDATE ESTUDIANTE_POR_CURSO SET Nota=90, Estado='E' WHERE IdCurso=10 AND IdEstudiante=7
UPDATE ESTUDIANTE_POR_CURSO SET Nota=80, Estado='E' WHERE IdCurso=10 AND IdEstudiante=8



EXEC SP_Insertar_Trabajo 'QAJobs', 'do QA on our system', '20', '2016-11-10', '2016-11-15', '', '10000'
EXEC SP_Insertar_Trabajo 'QAJobs', 'do QA on our system', '20', '2016-11-10', '2016-11-15', '', '10000'
EXEC SP_Insertar_Trabajo 'QAJobs', 'do QA on our system', '20', '2016-11-10', '2016-11-15', '', '10000'
EXEC SP_Insertar_Trabajo 'QAJobs', 'do QA on our system', '20', '2016-11-10', '2016-11-15', '', '10000'
EXEC SP_Insertar_Trabajo 'QAJobs', 'do QA on our system', '20', '2016-11-10', '2016-11-15', '', '10000'
EXEC SP_Insertar_Trabajo 'QAJobs', 'do QA on our system', '20', '2016-11-10', '2016-11-15', '', '10000'

UPDATE TRABAJO SET EstrellasObtenidas = 3, Exitoso = 0 WHERE ID=7
UPDATE TRABAJO SET EstrellasObtenidas = 4, Exitoso = 1 WHERE ID=8
UPDATE TRABAJO SET EstrellasObtenidas = 1, Exitoso = 0 WHERE ID=9
UPDATE TRABAJO SET Estado = 'E' WHERE ID>6
UPDATE TRABAJO SET EstrellasObtenidas = 4, Exitoso = 1 WHERE ID=10
UPDATE TRABAJO SET EstrellasObtenidas = 5, Exitoso = 1 WHERE ID=11
UPDATE TRABAJO SET EstrellasObtenidas = 4, Exitoso = 1 WHERE ID=12

DELETE TRABAJO_POR_ESTUDIANTE WHERE IdTrabajo>6

SELECT * FROM TRABAJO_POR_ESTUDIANTE

SELEct * from TRABAJO_POR_ESTUDIANTE
INSERT INTO TRABAJO_POR_ESTUDIANTE (IdTrabajo, IdEstudiante, Monto, FechaFinalizacion, Comentario, Estado)
VALUES (7, 7, 10000, '2016-11-17', 'The Emperor Protects!', 'A')
INSERT INTO TRABAJO_POR_ESTUDIANTE (IdTrabajo, IdEstudiante, Monto, FechaFinalizacion, Comentario, Estado)
VALUES (8, 7, 10000, '2016-11-17', 'The Emperor Protects!', 'A')
INSERT INTO TRABAJO_POR_ESTUDIANTE (IdTrabajo, IdEstudiante, Monto, FechaFinalizacion, Comentario, Estado)
VALUES (9, 7, 10000, '2016-11-17', 'The Emperor Protects!', 'A')
INSERT INTO TRABAJO_POR_ESTUDIANTE (IdTrabajo, IdEstudiante, Monto, FechaFinalizacion, Comentario, Estado)
VALUES (10, 8, 10000, '2016-11-17', 'The Emperor Protects!', 'A')
INSERT INTO TRABAJO_POR_ESTUDIANTE (IdTrabajo, IdEstudiante, Monto, FechaFinalizacion, Comentario, Estado)
VALUES (11, 8, 10000, '2016-11-17', 'The Emperor Protects!', 'A')
INSERT INTO TRABAJO_POR_ESTUDIANTE (IdTrabajo, IdEstudiante, Monto, FechaFinalizacion, Comentario, Estado)
VALUES (12, 8, 10000, '2016-11-17', 'The Emperor Protects!', 'A')



INSERT INTO PROYECTO (Nombre, Problematica, Descripcion, IdCurso, FechaInicio, FechaFinal, DocumentoAdicional, NotaObtenida, Estado)
VALUES ('Test', 'test this program', 'tests this programs api engine', 1, '2016-10-17', '2016-11-26', '', 70, 'E')
INSERT INTO PROYECTO (Nombre, Problematica, Descripcion, IdCurso, FechaInicio, FechaFinal, DocumentoAdicional, NotaObtenida, Estado)
VALUES ('Test', 'test this program', 'tests this programs api engine', 1, '2016-10-17', '2016-11-26', '', 65, 'E')
INSERT INTO PROYECTO (Nombre, Problematica, Descripcion, IdCurso, FechaInicio, FechaFinal, DocumentoAdicional, NotaObtenida, Estado)
VALUES ('Test', 'test this program', 'tests this programs api engine', 1, '2016-10-17', '2016-11-26', '', 50, 'F')

INSERT INTO PROYECTO (Nombre, Problematica, Descripcion, IdCurso, FechaInicio, FechaFinal, DocumentoAdicional, NotaObtenida, Estado)
VALUES ('Test', 'test this program', 'tests this programs api engine', 1, '2016-10-17', '2016-11-26', '', 85, 'E')
INSERT INTO PROYECTO (Nombre, Problematica, Descripcion, IdCurso, FechaInicio, FechaFinal, DocumentoAdicional, NotaObtenida, Estado)
VALUES ('Test', 'test this program', 'tests this programs api engine', 1, '2016-10-17', '2016-11-26', '', 90, 'E')
INSERT INTO PROYECTO (Nombre, Problematica, Descripcion, IdCurso, FechaInicio, FechaFinal, DocumentoAdicional, NotaObtenida, Estado)
VALUES ('Test', 'test this program', 'tests this programs api engine', 1, '2016-10-17', '2016-11-26', '', 20, 'F')

INSERT INTO PROYECTO_POR_ESTUDIANTE (IdProyecto, IdEstudiante, Estado)
VALUES (5, 7, 'A')
INSERT INTO PROYECTO_POR_ESTUDIANTE (IdProyecto, IdEstudiante, Estado)
VALUES (6, 7, 'A')
INSERT INTO PROYECTO_POR_ESTUDIANTE (IdProyecto, IdEstudiante, Estado)
VALUES (7, 7, 'A')
INSERT INTO PROYECTO_POR_ESTUDIANTE (IdProyecto, IdEstudiante, Estado)
VALUES (8, 8, 'A')
INSERT INTO PROYECTO_POR_ESTUDIANTE (IdProyecto, IdEstudiante, Estado)
VALUES (9, 8, 'A')
INSERT INTO PROYECTO_POR_ESTUDIANTE (IdProyecto, IdEstudiante, Estado)
VALUES (10,8, 'A')

INSERT INTO PROYECTO_POR_PROFESOR (IdProyecto, IdProfesor, Estado)
 VALUES (5, 13, 'A')
INSERT INTO PROYECTO_POR_PROFESOR (IdProyecto, IdProfesor, Estado)
 VALUES (6, 13, 'A')
INSERT INTO PROYECTO_POR_PROFESOR (IdProyecto, IdProfesor, Estado)
 VALUES (7, 13, 'A')
INSERT INTO PROYECTO_POR_PROFESOR (IdProyecto, IdProfesor, Estado)
 VALUES (8, 13, 'A')
INSERT INTO PROYECTO_POR_PROFESOR (IdProyecto, IdProfesor, Estado)
 VALUES (9, 13, 'A')
INSERT INTO PROYECTO_POR_PROFESOR (IdProyecto, IdProfesor, Estado)
 VALUES (10, 13, 'A')