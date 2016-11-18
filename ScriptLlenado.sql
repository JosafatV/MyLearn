Use MyLearnDB;
GO

EXEC SP_Insertar_Universidad 'Instituto Tecnologico de Costa Rica'
EXEC SP_Insertar_Universidad 'Universidad Nacional'
EXEC SP_Insertar_Universidad 'Universidad de Costa Rica'

EXEC SP_Insertar_Tecnologia 'SQL'
EXEC SP_Insertar_Tecnologia 'HTML'
EXEC SP_Insertar_Tecnologia 'C#'

EXEC SP_Insertar_Estudiante '1', '1234', 'gsg4aer6g4ar68g46r5g', 'Drive', 'thrj4=56d3k', 'Gabriel', 'Angelos', '09-0873-0544', 'Gabriel@gmail.com', 85748231, 'Costa Rica', 'San Jose', '11/15/2016','GabrielA', 'rg38a4gr8a4r3g8a7r4g'
EXEC SP_Insertar_Estudiante '2', '1234', '4adfn98g4ar65g4ar98n', 'Drive', '45gf3=l4h53', 'Nathaniel','Garro', '02-0623-0463', 'Nathaniel@gmail.com', 89843549, 'Costa Rica', 'San Jose', '11/15/2016','NathanielG', '8g34arg863a74rgarg38' 
EXEC SP_Insertar_Estudiante '3', '1234', 'gt4ar64a664a6r8g34ar', 'Drive', 'k4563=kp4j3', 'Sebastian', 'Yarrick','05-0780-0642', 'Sebastian@gmail.com', 86548943, 'Costa Rica', 'Heredia', '11/15/2016','SebastianY', 'a4gr8a4r3g8a7r4g8a7r'
EXEC SP_Insertar_Estudiante '4', '1234', 'g863a74rgarg38a4gr8a', 'Drive', 'iopbg=ny878', 'Logan', 'Grimnar', '04-0521-0623', 'Logan@gmail.com', 82189432, 'Costa Rica', 'San Jose', '11/15/2016', 'LoganG', 'ega87hh36a47812a6gr7'
EXEC SP_Insertar_Estudiante '5', '1234', '4r3g8a7r4g8a7rega87h', 'Drive', '64a6r=8g34a', 'Gregor', 'Eisenhorn', '05-0645-0450', 'Gregor@gmail.com', 81652721, 'Costa Rica', 'Heredia', '11/15/2016','GregorE', '878ilo34kghj83gh7k8d'
EXEC SP_Insertar_Estudiante '6', '1234', 'h36a47812a6gr78k78il', 'Drive', 'g863a=74rga', 'Ragnar', 'Blackmane', '09-0787-0460', 'Ragnar@gmail.com', 87312731, 'Costa Rica', 'San Jose', '11/15/2016','RagnarB', '3h4ar8697u8lo74il853'
EXEC SP_Insertar_Estudiante '7', '1234', 'o34kghj83gh7k8d3h4ar', 'Drive', 'g38a4=gr8a4', 'Davian', 'Thule', '08-0978-0705', 'Davian@gmail.com', 82761273, 'Costa Rica', 'San Jose', '11/15/2016','DavianT', 'tx586h7s35h7ga863f4g'
EXEC SP_Insertar_Estudiante '8', '1234', '8697u8lo74il853tx586', 'Drive', '3g8a7=r4g8a', 'Alicia', 'Dominica', '07-0698-0870', 'Alicia@gmail.com', 85126514, 'Costa Rica', 'Heredia', '11/15/2016','AliciaD','fjniglk5g36f45jg3x54'
EXEC SP_Insertar_Estudiante '9', '1234', 'h7s35h7ga863f4gfjnig', 'Drive', 'rega8=7hh36', 'Selena', 'Agna', '03-0542-0055', 'Selena@gmail.com', 89198472, 'Costa Rica', 'San Jose', '11/15/2016','SelenaA', '345yul3g6ty3d4563thr'
EXEC SP_Insertar_Estudiante '10', '1234', 'lk5g36f45jg3x54345yu', 'Drive', '47812=a6gr7', 'Anais', 'Kaurava','04-0028-0954', 'Anais@gmail.com', 89874289, 'Costa Rica', 'San Jose', '11/15/2016','AnaisK', 'j456d3k45gf3l4h53jk4'
EXEC SP_Insertar_Estudiante '11', '1234', 'l3g6ty3d45thrj456d3k', 'Drive', '878il=o34kg', 'Olga', 'Karamanz', '06-0723-0455', 'Olga@gmail.com', 84791285, 'Costa Rica', 'San Jose', '11/15/2016','OlgaK', '563kp4j3uiopbgny878c'
EXEC SP_Insertar_Estudiante '12', '1234', '45gf3l4h53jk4563kp4j', 'Drive', 'hj83g=h7k8d', 'Katherine', 'Elysius', '06-0046-0240', 'Katherine@gmail.com', 86152783, 'Costa Rica', 'Heredia', '11/15/2016','KatherineE', 'r6789xs64a6r8g34arg8'

EXEC SP_Insertar_Profesor '13','1234','f4gfjniglk5g36f45jg3','Drive','3g6ty=3d456','Ada','Lovelace','Ada@gmail.com',27658127,'11/15/2016','Lunes y Miercoles 9:30 a 12:30','Costa Rica','San Jose', '1'
EXEC SP_Insertar_Profesor '14', '1234','x54345yul3g6ty3d4563','Drive','3thrj=4564a','Blaise','Pascal','Blaise@gmail.com',22935176,'11/15/2016','Martes y Jueves 7:30 a 9:30','Costa Rica','San Jose', '1'
EXEC SP_Insertar_Profesor '15','1234','97u8lo74il853tx586h7','Drive','6r8g3=4arg8','Carl','Sagan','Carl@gmail.com',26250687,'11/15/2016','Miercoles y Viernes 13:00 a 15:00','Costa Rica','San Jose', '1'
EXEC SP_Insertar_Profesor '16','1234','s35h7ga863f4gfjniglk','Drive','63a74=rgarg','Heinrich','Hertz','Heinrich@gmail.com',22506892,'11/15/2016','Miercoles y Viernes 13:00 a 15:00','Costa Rica','San Jose', '1'
EXEC SP_Insertar_Profesor '17','1234','5g36f45jg3x54345yul3','Drive','38a4g=r8a4r','Gottfried','Leibniz','Gottfried@gmail.com',24565424,'11/15/2016','Lunes y Miercoles 9:30 a 12:30','Costa Rica','San Jose', '1'
EXEC SP_Insertar_Profesor '18','1234','g6ty3d4563thrj456d3k','Drive','3g8a7=r4g8a','Beatrix','Potter','Beatrix@gmail.com',25560462,'11/15/2016','Miercoles y Viernes 13:00 a 15:00','Costa Rica','San Jose', '1'
EXEC SP_Insertar_Profesor '19','1234','853tx586h7s35h7ga863','Drive','3x543=45yul','Edwin','Hubble','Edwin@gmail.com',27946215,'11/15/2016','Martes y Jueves 7:30 a 9:30','Costa Rica','Heredia', '2'


EXEC SP_Insertar_Empresa '20','1234','3uiopbgny878cr6789xs','Drive','3h4ar=8697u','Ernest','Rutherford','Marte','Marte41@gmail.com',25417489,'11/15/2016','http://warhammer40k.wikia.com/wiki/Mars','Costa Rica','San Jose','Marte41'											
EXEC SP_Insertar_Empresa '21','1234','3rer8g34arg863a74rga','Drive','8lo74=il853','Andrey','Sakharov','Lucius','Lucius18@gmail.com',22298517,'11/15/2016','http://warhammer40k.wikia.com/wiki/Lucius','Costa Rica','San Jose','Lucius18'											
EXEC SP_Insertar_Empresa '22','1234','rg38a4gr8a4r3g8a7r4g','Drive','tx586=h7s35','Claude','Shannon','Agripinaa','Agripinaa01@gmail.com',26523798,'11/15/2016','http://warhammer40k.wikia.com/wiki/Agripinaa','Costa Rica','Heredia','Agripinaa01'											
EXEC SP_Insertar_Empresa '23','1234','8a7rega87hh36a47812a','Drive','7ga86=3f4gf','Leonard','Euler','Stygies Ocho','Stygies8@gmail.com',25173952,'11/15/2016','http://warhammer40k.wikia.com/wiki/Stygies_VIII','Costa Rica','San Jose','Stygies8'											
EXEC SP_Insertar_Empresa '24','1234','6gr788ilo34kghj83gh7','Drive','niglk=5g36f','Michael','Faraday','Graia','Graia13@gmail.com',21761576,'11/15/2016','http://warhammer40k.wikia.com/wiki/Graia','Costa Rica','Heredia','Graia13'											
EXEC SP_Insertar_Empresa '25','1234','k8d3h4ar8697u8lo74il','Drive','niglk=5g36f','Richard','Feynman','Metalica','Metalica7@gmail.com',28247921,'11/15/2016','http://warhammer40k.wikia.com/wiki/Metalica','Costa Rica','San Jose','Metalica7'											
EXEC SP_Insertar_Empresa '26','1234','853tx586h7s35h7ga863','Drive','3x543=45yul','Rosalind','Franklin','Ryza','Ryza30@gmail.com',27946215,'11/15/2016','http://warhammer40k.wikia.com/wiki/Ryza','Costa Rica','San Jose','Ryza30'											


EXEC SP_Insertar_Admin '27','1234','45gf3l4h53jk4563kp4j', '', '', 'Joseph','Campos'
EXEC SP_Insertar_Admin '28','1234','3uiopbgny878cr6789xs', '', '', 'Sebastian','Gonzalez'
EXEC SP_Insertar_Admin '29','1234','3re6d3k45gf3l4h53jk4', '', '','Josafat','Vargas'
EXEC SP_Insertar_Admin '30','1234','563kp4j3uiopbgny878c', '', '', 'Giovanni','Villalobos'


INSERT INTO *****************************************************************************

EXEC SP_Insertar_Curso '13', 'Especificacion y Diseño de Software', 'CE-4101', '1'

/*CE-4101*/
EXEC SP_Insertar_Badge 'Usabilidad', '25', '1'
EXEC SP_Insertar_Badge 'Diagramas de Diseño', '25', '1'
EXEC SP_Insertar_Badge 'Especificación de Proyectos', '25', '1'
EXEC SP_Insertar_Badge 'Patrones de Diseño', '25', '1'


EXEC SP_Insertar_Proyecto '1', 'DigiLearn', 'La ausencia de una plataforma para trabajar en línea y obtener experiencia laboral','ofrecer un sericio a estudiantes para que puedan trabajar en cursos de su universidad y en ofertas de trabajo', '1', '10/17/2016', '11/26/2016', '', 70

EXEC SP_Insertar_Trabajo 'Decripción de STCs', 'Gran cantidad de informacion se encuentra en este STC, es necesario decriptarlo', '20', '11/10/2016', '12/01/2016', ''
EXEC SP_Insertar_Trabajo 'DrPischel', 'Para ser más competitivo la farmacia DrPischel desea crear un sistema de atención en línea, donde los usuarios puedan pre-ordenar medicamentos para facilitar su recolección', '20', '10/17/2016', '11/26/2016', ''
						
EXEC SP_Crear_Propuesta_Subasta 2, '1', 35000, 'Knowledge is power, Guard it well!'
EXEC SP_Crear_Propuesta_Subasta 2, '2', 55000, 'Sisters, we must go as Martyrs! We must go up in flames!'
								
EXEC SP_Aceptar_Subasta '2'

EXEC SP_Insertar_Mensaje_Trabajo 'Por favor enviarme una propuesta inicial del proyecto', '', '10/17/2016', '2'
EXEC SP_Insertar_Respuesta '1', 'Aquí adjunto la propuesta', '', '10/18/2016'
EXEC SP_Insertar_Mensaje_Trabajo 'Necesito que me envie el perfil de la empresa', '', '10/18/2016', '2'

EXEC SP_Insertar_Notificacion 'Felicidades! Usted ha ganado el proyecto Drpischel', '10/17/2016', '1'

EXEC SP_Agregar_Al_Curso '1', '1'
EXEC SP_Agregar_Al_Curso '2', '1'


