using Microsoft.AspNetCore.Mvc;

using Models;

namespace CineApi.Controllers
{
    [ApiController]
    [Route("CinemaParaiso/[controller]")]
    public class PeliculaController : ControllerBase
    {
        public static List<Pelicula> peliculas = new List<Pelicula>();

        [HttpGet]
        public ActionResult<IEnumerable<Pelicula>> GetAll()
        {
            return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public ActionResult<Pelicula> GetById(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.IdPelicula == id);
            if (pelicula == null)
                return NotFound();
            return Ok(pelicula);
        }
        [HttpGet("categoria")]
        public ActionResult<IEnumerable<Pelicula>> GetByCategory([FromQuery] int idCategoriaPelicula)
        {
            var peliculasPorCategoria = peliculas.Where(p => p.IdCategoriaPelicula == idCategoriaPelicula).ToList();
            if (peliculasPorCategoria == null)
                return NotFound();
            return Ok(peliculasPorCategoria);
        }



        [HttpPost]
        public ActionResult<Pelicula> Create([FromBody] Pelicula pelicula)
        {
            peliculas.Add(pelicula);
            return CreatedAtAction(nameof(GetById), new { id = pelicula.IdPelicula }, pelicula);
        }

///////////////////////////////////////////////////////////////////////////////////////////De momento no se necesita el UPDATE
        // [HttpPut("{id}")]
        // public ActionResult Update(int id, [FromBody] Pelicula updatedPelicula)
        // {
        //     var pelicula = peliculas.FirstOrDefault(p => p.IdPelicula == id);
        //     if (pelicula == null)
        //         return NotFound();

        //     pelicula.Nombre = updatedPelicula.Nombre;
        //     pelicula.Duracion = updatedPelicula.Duracion;
        //     pelicula.Actores = updatedPelicula.Actores;
        //     pelicula.EdadMinima = updatedPelicula.EdadMinima;
        //     pelicula.FechaEstreno = updatedPelicula.FechaEstreno;
        //     pelicula.Horario = updatedPelicula.Horario;
        //     pelicula.Descripcion = updatedPelicula.Descripcion;

            
        //     return NoContent();
        // }

///////////////////////////////////////////////////////////////////////////////////////////De momento no se necesita el DELETE
        // [HttpDelete("{id}")]
        // public ActionResult Delete(int id)
        // {
        //     var pelicula = peliculas.FirstOrDefault(p => p.IdPelicula == id);
        //     if (pelicula == null)
        //         return NotFound();

        //     peliculas.Remove(pelicula);
        //     return NoContent();
        // }

public static void InicializarDatos()
{
    peliculas.Add(new Pelicula(1, "El señor de los anillos", "../imgs/ElSeñorDeLosAnillos.png",  "Peter Jackson", 178, "Elijah Wood, Ian McKellen, Viggo Mortensen", "+12", new DateTime(2001, 12, 19), "Frodo Bolsón y su grupo de amigos deben destruir un anillo mágico para evitar que el malvado Sauron conquiste el mundo.", 2, "Clásicos", 
            "https://www.youtube.com/embed/3GJp6p_mgPo"));

            peliculas.Add(new Pelicula(2, "Harry Potter", "../imgs/harrypotter1.jpg",  "Chris Columbus",152, "Daniel Radcliffe, Rupert Grint, Emma Watson", "+7", new DateTime(2001, 11, 10), "Harry Potter descubre que es un mago y asiste a la escuela Hogwarts para aprender magia, enfrentándose al malvado Voldemort.", 2, "Clásicos", 
            "https://www.youtube.com/embed/WE4AJuIvG1Y"));

            peliculas.Add(new Pelicula(3, "Star Wars: Episodio IV ", "../imgs/StarWars.jpg",  "George Lucas",121, "Mark Hamill, Harrison Ford, Carrie Fisher", "+7", new DateTime(1977, 5, 25), "Un joven llamado Luke Skywalker se une a la rebelión contra el imperio galáctico para salvar a la princesa Leia.", 2, "Clásicos", 
            "https://www.youtube.com/embed/beAH5vea99k"));

            peliculas.Add(new Pelicula(4, "El mago de Oz", "../imgs/MagodeOZ.jpg",  "Victor Fleming",102, "Judy Garland, Frank Morgan, Ray Bolger", "+7", new DateTime(1939, 8, 25), "Dorothy es llevada por un tornado a la tierra de Oz, donde hará nuevos amigos mientras busca el camino de vuelta a casa.", 2, "Clásicos", 
            "https://www.youtube.com/embed/d1h4rUzcKGg"));

            peliculas.Add(new Pelicula(5, "Caza fantasmas", "../imgs/CazFantasmas.jpg",  "Ivan Reitman",105, "Bill Murray, Dan Aykroyd, Sigourney Weaver", "+12", new DateTime(1984, 6, 8), "Un grupo de científicos inicia una empresa para capturar fantasmas en Nueva York, enfrentándose a una creciente invasión paranormal.", 2, "Clásicos", 
            "https://www.youtube.com/embed/gDPfArhkg7M"));

            peliculas.Add(new Pelicula(6, "E.T. el extraterrestre", "../imgs/ET.jpg",  "Steven Spielberg",115, "Henry Thomas, Drew Barrymore, Peter Coyote", "+7", new DateTime(1982, 6, 11), "Un niño llamado Elliott forma una amistad con un extraterrestre llamado E.T., quien intenta regresar a su hogar en el espacio.", 2, "Clásicos", 
            "https://www.youtube.com/watch?v=3WbZuH6i9Vo"));

            peliculas.Add(new Pelicula(7, "Piratas del Caribe", "../imgs/PiratasdelCaribe.jpg",  "Gore Verbinski",143, "Johnny Depp, Orlando Bloom, Keira Knightley", "+12", new DateTime(2003, 7, 9), "El capitán Jack Sparrow se une a un grupo para buscar un tesoro perdido, mientras enfrenta una maldición que convierte a los piratas en esqueletos.", 2, "Clásicos", 
            "https://www.youtube.com/embed/5Itr2jHuJaw"));

            peliculas.Add(new Pelicula(8, "Indiana Jones", "../imgs/IndianaJones.jpg",  "Steven Spielberg",115, "Harrison Ford, Karen Allen, Paul Freeman", "+12", new DateTime(1981, 6, 12), "El arqueólogo Indiana Jones viaja por el mundo para encontrar el Arca de la Alianza antes de que los nazis lo consigan.", 2, "Clásicos", 
            "https://www.youtube.com/embed/ceMf9xtDA6U"));

            peliculas.Add(new Pelicula(9, "Regreso al futuro", "../imgs/RegresoalFuturo.jpg",  "Robert Zemeckis",116, "Michael J. Fox, Christopher Lloyd, Lea Thompson", "+12", new DateTime(1985, 7, 3), "Marty McFly viaja en el tiempo usando una máquina del tiempo inventada por el doctor Emmett Brown, pero su viaje pone en peligro su propia existencia.", 2, "Clásicos", 
            "https://www.youtube.com/embed/NDS1myoYUzs"));

            peliculas.Add(new Pelicula(10, "Psicosis", "../imgs/Psicosis.jpg",  "Alfred Hitchcock",109, "Anthony Perkins, Janet Leigh, Vera Miles", "+18", new DateTime(1960, 6, 16), "Una mujer en fuga se refugia en un motel, donde se encuentra con un misterioso gerente, Norman Bates, en una serie de eventos que desatan el terror.", 3, "Terror", 
            "https://www.youtube.com/embed/mC2gOyWuSEY"));

            peliculas.Add(new Pelicula(11, "El resplandor", "../imgs/ElResplandor.jpg",  "Stanley Kubrick",146, "Jack Nicholson, Shelley Duvall, Danny Lloyd", "+18", new DateTime(1980, 5, 23), "Un escritor acepta un trabajo como cuidador de un hotel aislado, donde su familia se ve aterrorizada por fenómenos paranormales.", 3, "Terror", 
            "https://www.youtube.com/embed/f7ADL4i_eCQ"));

            peliculas.Add(new Pelicula(12, "Viernes 13", "../imgs/Viernes13.jpg",  "Sean S. Cunningham",95, "Betsy Palmer, Adrienne King, Harry Crosby", "+18", new DateTime(1980, 5, 9), "Un grupo de jóvenes va a trabajar en un campamento de verano abandonado, pero se encuentran con un asesino enmascarado que acecha la zona.", 3, "Terror", 
            "https://www.youtube.com/embed/MfwLgrasoqs"));

            peliculas.Add(new Pelicula(13, "Pesadilla en Elm Street", "../imgs/PesadillaElmstreet.jpg", "Wes Craven", 91, "Heather Langenkamp, Johnny Depp, Robert Englund", "+18", new DateTime(1984, 11, 9), "Un grupo de jóvenes es acechado por Freddy Krueger, un asesino que mata en los sueños, lo que los lleva a luchar por sus vidas.", 3, "Terror", 
            "https://www.youtube.com/embed/MfwLgrasoqs"));

            peliculas.Add(new Pelicula(14, "Déjame salir", "../imgs/DejameSalir.jpg",  "Jordan Peele",104, "Daniel Kaluuya, Allison Williams, Catherine Keener", "+18", new DateTime(2017, 2, 24), "Un joven visita a los padres de su novia, pero pronto descubre que su familia oculta oscuros secretos que amenazan su vida.", 3, "Terror", 
            "https://www.youtube.com/embed/P9wb4fgOImc"));

            peliculas.Add(new Pelicula(15, "IT", "../imgs/IT.jpg",  "Andy Muschietti",135, "Bill Skarsgård, Jaeden Lieberher, Finn Wolfhard", "+18", new DateTime(2017, 9, 8), "Un grupo de niños se enfrenta a un malvado payaso que resurge cada 27 años para sembrar el terror en su pueblo.", 3, "Terror", 
            "https://www.youtube.com/embed/_oBZ_zTz0Nw"));

            peliculas.Add(new Pelicula(16, "Pulp Fiction", "../imgs/pulpfiction.jpg",  "Quentin Tarantino",154, "John Travolta, Uma Thurman, Samuel L. Jackson", "+18", new DateTime(1994, 10, 14), "El destino de varios personajes se entrelaza a través de una serie de historias no lineales llenas de acción, diálogos agudos y violencia estilizada.", 4, "De Director", 
            "https://www.youtube.com/embed/ZFYCXAG6fdo"));

            peliculas.Add(new Pelicula(17, "Malditos Bastardos", "../imgs/malditosBastardos.png",  "Quentin Tarantino",153, "Brad Pitt, Christoph Waltz, Michael Fassbender", "+18", new DateTime(2009, 8, 21), "Un grupo de soldados estadounidenses se infiltran en territorio nazi para asesinar a líderes del Tercer Reich, mientras una mujer judía busca vengarse de los nazis.", 4, "De Director", 
            "https://www.youtube.com/embed/2jcTRi8D80k"));

            peliculas.Add(new Pelicula(18, "Django sin cadenas", "../imgs/Django.jpg",  "Quentin Tarantino",165, "Jamie Foxx, Christoph Waltz, Leonardo DiCaprio", "+18", new DateTime(2012, 12, 25), "Un esclavo liberado se asocia con un cazador de recompensas para rescatar a su esposa de un terrateniente cruel.", 4, "De Director", 
            "https://www.youtube.com/embed/CLofzNkIqAc"));


            peliculas.Add(new Pelicula(19, "La forma del agua", "../imgs/LaFormaDelAgua.jpg",  "Guillermo del Toro",123, "Sally Hawkins, Michael Shannon, Richard Jenkins", "+12", new DateTime(2017, 12, 8), "Una muda mujer se enamora de una criatura anfibia retenida en un laboratorio secreto durante la Guerra Fría.", 4, "De Director", 
            "https://www.youtube.com/embed/gfVe2puMBs0"));

            peliculas.Add(new Pelicula(20, "Bitelchus", "../imgs/Bitelchus.jpg",  "Tim Burton",92, "Michael Keaton, Alec Baldwin, Geena Davis", "+12", new DateTime(1988, 3, 30), "Una pareja de fantasmas reclaman ayuda de un excéntrico ser para espantar a los nuevos ocupantes de su casa.", 4, "De Director", 
            "https://www.youtube.com/embed/Gpg6OzvwuiA"));

            peliculas.Add(new Pelicula(21, "Érase una vez en Hollywood", "../imgs/EraseUnaVezEnHollywood.png",  "Quentin Tarantino",161, "Leonardo DiCaprio, Brad Pitt, Margot Robbie", "+18", new DateTime(2019, 7, 26), "Un actor y su doble de acción luchan por encontrar su lugar en la industria del cine de los años 60 en Hollywood, durante la transición del cine clásico al cine moderno.", 4, "De Director", 
            "https://www.youtube.com/embed/J0rFGJV3cYw"));

            peliculas.Add(new Pelicula(22, "Pinocho", "../imgs/Pinocho.jpg",  "Guillermo del Toro",117, "Gregory Mann, Ewan McGregor, David Bradley", "+7", new DateTime(2022, 12, 9), "Un artesano solitario crea una marioneta que cobra vida, llevando a la criatura a vivir aventuras en un mundo de fantasía oscura.", 4, "De Director", 
            "https://www.youtube.com/embed/-WgZ_IQU0Ks"));

            peliculas.Add(new Pelicula(23, "Los odiosos 8", "../imgs/Odiosos8.jpg",  "Quentin Tarantino",168, "Samuel L. Jackson, Kurt Russell, Jennifer Jason Leigh", "+18", new DateTime(2015, 12, 25), "Ocho desconocidos se encuentran atrapados en una cabaña durante una tormenta de nieve, lo que desata una serie de giros violentos y traiciones.", 4, "De Director", 
            "https://www.youtube.com/embed/JxVRgBOL8jc"));

            peliculas.Add(new Pelicula(24, "El caballero oscuro", "../imgs/CaballeroOscuroBegins.jpg",  "Christopher Nolan",152, "Christian Bale, Heath Ledger, Aaron Eckhart", "+12", new DateTime(2008, 7, 18), "Batman debe enfrentarse al Joker, un villano que quiere desestabilizar Gotham City a través de la anarquía y el caos.", 5, "Superhéroes", 
            "https://www.youtube.com/embed/JIGLjChePqk"));

            peliculas.Add(new Pelicula(25, "El caballero oscuro: La leyenda renace", "../imgs/CaballeroOscuro2.jpg",  "Christopher Nolan",164, "Christian Bale, Tom Hardy, Anne Hathaway", "+12", new DateTime(2012, 7, 20), "Batman regresa a Gotham para enfrentarse a Bane, un terrorista que planea destruir la ciudad y acabar con la leyenda del caballero oscuro.", 5, "Superhéroes", 
            "https://www.youtube.com/embed/e0qwi-4iOpE"));

            peliculas.Add(new Pelicula(26, "El caballero oscuro", "../imgs/CaballeroOscuro1.jpg",  "Christopher Nolan",164, "Christian Bale, Michael Caine, Gary Oldman", "+12", new DateTime(2012, 7, 20), "La última entrega de la trilogía de Batman, donde el caballero oscuro se enfrenta a los villanos más temibles para salvar Gotham.", 5, "Superhéroes", 
            "https://www.youtube.com/embed/Qs-NylETt1E"));

            peliculas.Add(new Pelicula(27, "Spiderman", "../imgs/Spiderman.jpg",  "Sam Raimi",121, "Tobey Maguire, Kirsten Dunst, Willem Dafoe", "+7", new DateTime(2002, 5, 3), "Peter Parker, un joven estudiante, recibe habilidades especiales tras ser mordido por una araña radiactiva, convirtiéndose en Spiderman para proteger a Nueva York.", 5, "Superhéroes", 
            "https://www.youtube.com/embed/t06RUxPbp_c"));

            peliculas.Add(new Pelicula(28, "The Batman", "../imgs/TheBatman.jpg",  "Matt Reeves",155, "Robert Pattinson, Zoë Kravitz, Paul Dano", "+12", new DateTime(2022, 3, 4), "El joven Bruce Wayne investiga una serie de crímenes en Gotham City, enfrentándose al Enigma, quien pone en peligro la ciudad.", 5, "Superhéroes", 
            "https://www.youtube.com/embed/IqRRLA6pZvo"));

            peliculas.Add(new Pelicula(29, "Vengadores: Infinity War", "../imgs/InfinityWar.jpg",  "Anthony Russo, Joe Russo",149, "Robert Downey Jr., Chris Hemsworth, Mark Ruffalo", "+12", new DateTime(2018, 4, 27), "Los Vengadores y sus aliados luchan contra Thanos, quien busca recoger las Gemas del Infinito para destruir la mitad del universo.", 5, "Superhéroes", 
            "https://www.youtube.com/embed/wJbudwIF0cE"));

            peliculas.Add(new Pelicula(30, "Kick Ass", "../imgs/KickAss.jpg",  "Matthew Vaughn",117, "Aaron Taylor-Johnson, Nicolas Cage, Chloe Grace Moretz", "+12", new DateTime(2010, 4, 16), "Un adolescente decide convertirse en un superhéroe, aunque carece de habilidades especiales, y se une a otros personajes con poderes inusuales.", 5, "Superhéroes", 
            "https://www.youtube.com/embed/hLFcik85gMY"));

            peliculas.Add(new Pelicula(31, "Rango", "../imgs/Rango.jpg", "Gore Verbinski", 107, "Johnny Depp, Isla Fisher, Timothy Olyphant", "+7", new DateTime(2011, 3, 4), "Un camaleón se convierte en el sheriff de un pueblo desértico y debe enfrentarse a un malvado forajido que amenaza la paz del lugar.", 6, "Animación", 
            "https://www.youtube.com/embed/5YPoi-I7s24"));

            peliculas.Add(new Pelicula(32, "Toy Story", "../imgs/ToyStory.jpg",  "John Lasseter",81, "Tom Hanks, Tim Allen, Don Rickles", "+7", new DateTime(1995, 11, 22), "Los juguetes de un niño cobran vida cuando no están siendo observados, pero enfrentan un peligro cuando Woody, su líder, se ve amenazado por un nuevo juguete.", 6, "Animación", 
            "https://www.youtube.com/embed/cY6R14NBCto"));

            peliculas.Add(new Pelicula(33, "Miles Morales: Spiderman 1", "../imgs/SpidermanUnNuevoUniverso.jpg", "Bob Persichetti, Peter Ramsey, Rodney Rothman", 117, "Shameik Moore, Jake Johnson, Hailee Steinfeld", "+7", new DateTime(2018, 12, 14), "Miles Morales, un adolescente de Nueva York, se convierte en el nuevo Spider-Man, pero debe enfrentarse a una dimensión paralela llena de otros Spideys.", 6, "Animación", 
            "https://www.youtube.com/embed/g4Hbz2jLxvQ"));

            peliculas.Add(new Pelicula(34, "Miles Morales: Spiderman 2", "../imgs/SpiderManATravésDelSpiderVerso.jpg",  "Joaquim Dos Santos, Kemp Powers, Justin K. Thompson",140, "Shameik Moore, Hailee Steinfeld, Oscar Isaac", "+7", new DateTime(2023, 6, 2), "Miles Morales regresa al Spider-Verso, donde se enfrenta a nuevos retos mientras busca salvar el multiverso de una amenaza gigantesca.", 6, "Animación", 
            "https://www.youtube.com/embed/b_yMOiRgMmQ"));

            peliculas.Add(new Pelicula(35, "Buscando a Nemo", "../imgs/Nemo.jpg",  "Andrew Stanton",100, "Albert Brooks, Ellen DeGeneres, Alexander Gould", "+7", new DateTime(2003, 5, 30), "Un pez payaso llamado Marlin recorre el océano en busca de su hijo perdido, Nemo, enfrentándose a diversos desafíos en su aventura.", 6, "Animación", 
            "https://www.youtube.com/embed/ic53iM_WZWs"));

            peliculas.Add(new Pelicula(36, "Shrek", "../imgs/Shrek.jpg",  "Andrew Adamson, Vicky Jenson",90, "Mike Myers, Eddie Murphy, Cameron Diaz", "+7", new DateTime(2001, 4, 22), "Un ogro llamado Shrek se embarca en una misión para rescatar a la princesa Fiona, en un cuento que parodia los clásicos de hadas.", 6, "Animación", 
            "https://www.youtube.com/embed/B88JfTyJ1Fw"));

            peliculas.Add(new Pelicula(37, "Pesadilla antes de Navidad", "../imgs/PesadillaAntesDeNavidad.png", "Henry Selick", 76, "Danny Elfman, Chris Sarandon, Catherine O'Hara", "+7", new DateTime(1993, 10, 29), "Jack Skellington, el rey de Halloween Town, descubre la Navidad y decide hacerse cargo de las festividades, con resultados desastrosos.", 6, "Animación", 
            "https://www.youtube.com/embed/-hl89kMUK2M"));
                        



            peliculas.Add(new Pelicula(38, "RED ONE","../imgs/RedOne.jpg","Jake Kasdan", 148, "Nick Kroll, Dwayne Johnson, Chris Evans, Kristofer Hivju, Kiernan Shipka, Bonnie Hunt, Mary Elizabeth Ellis, Wesley Kimmel, Lucy Liu, J.K. Simmons",
            "+7", new DateTime(2024, 11, 6),
            "Tras el secuestro de Papá Noel, nombre en clave: RED ONE, el Jefe de Seguridad del Polo Norte (Dwayne Johnson) debe formar equipo con el cazarrecompensas más infame del mundo (Chris Evans) en una misión trotamundos llena de acción para salvar la Navidad. No te pierdas #RedOne, protagonizada por Dwayne Johnson y Chris Evans. Disfruta de la película a partir del 6 noviembre solo en cines.",
            1,"Estrenos","https://www.youtube.com/embed/HMFK7mzUEKI"));      
            peliculas.Add(new Pelicula(39, "VENOM 3", "../imgs/venom3.jpg","Kelly Marcel", 138, "Rhys Ifans, Chiwetel Ejiofor, Tom Hardy, Stephen Graham, Alanna Ubach, Juno Temple, Clark Backo, Peggy Lu",
            "+12", new DateTime(2024, 10, 25),
            "Eddie y Venom están a la fuga. Perseguidos por sus sendos mundos y cada vez más cercados, el dúo se ve abocado a tomar una decisión devastadora que hará que caiga el telón sobre el último baile de Venom y Eddie.",
            1,"Acción", "https://www.youtube.com/embed/wuXjTZjYZQY"));
            peliculas.Add(new Pelicula(40, "GLADIATOR II", "../imgs/Gladiator2.jpg","Ridley Scott", 138, "Paul Mescal, Denzel Washington, Connie Nielsen, Joseph Quinn, Derek Jacobi, Fred Hechinger, Lior Raz, Pedro Pascal",
            "+16", new DateTime(2024, 11, 15),
            "Años después de presenciar la muerte del admirado héroe Máximo a manos de su tío, Lucio (Paul Mescal) se ve forzado a entrar en el Coliseo tras ser testigo de la conquista de su hogar por parte de los tiránicos emperadores que dirigen Roma con puño de hierro. Con un corazón desbordante de furia y el futuro del imperio en juego, Lucio debe rememorar su pasado en busca de la fuerza y el honor que devuelvan al pueblo la gloria perdida de Roma.",
            1,"Acción", "https://www.youtube.com/embed/vZQm2ZRYz00"));
            peliculas.Add(new Pelicula(41, "TERRIFIER 3", "../imgs/Terrifier3.jpeg","Chris Sanders", 100, "Bill Nighy, Lupita Nyong'o, Stephanie Hsu, Mark Hamill, Ving Rhames, Matt Berry, Pedro Pascal, Kit Connor",
            "+18", new DateTime(2024, 10, 11),
            "La película sigue el épico viaje de un robot -la unidad 7134 de Roz, 'ROZ' para abreviar- que naufraga en una isla deshabitada y debe aprender a adaptarse al duro entorno, entablando gradualmente relaciones con los animales de la isla y convirtiéndose en padre adoptivo de un gosling huérfano.",
            1,"Terror", "https://www.youtube.com/embed/zaPcin5knJk"));
            peliculas.Add(new Pelicula(42, "DUNE: PARTE DOS", "../imgs/Dune2.jpg", "Denis Villeneuve", 155, "Timothée Chalamet, Zendaya, Rebecca Ferguson, Javier Bardem, Josh Brolin, Dave Bautista, Florence Pugh, Austin Butler, Christopher Walken",
            "+12", new DateTime(2024, 11, 3),
            "Paul Atreides une fuerzas con los Fremen para vengar la conspiración contra su familia mientras intenta evitar un oscuro destino en el que él mismo podría transformarse en un tirano. La guerra por el control del desértico planeta de Arrakis continúa en esta espectacular segunda entrega.",
            1,"Ciencia Ficción", "https://www.youtube.com/embed/Qv7I3wDfFzI"));

            peliculas.Add(new Pelicula(43, "THE BATMAN: CAPÍTULO DOS", "../imgs/TheBatman2.jpeg", "Matt Reeves", 185, "Robert Pattinson, Zoë Kravitz, Paul Dano, Colin Farrell, Jeffrey Wright, Andy Serkis, John Turturro",
            "+16", new DateTime(2025, 3, 15),
            "La ciudad de Gotham continúa siendo un campo de batalla para Batman, quien ahora debe enfrentarse a nuevos enemigos que ponen a prueba sus habilidades, y cuestionan hasta dónde está dispuesto a llegar para proteger la ciudad.",
            1,"Acción", "https://www.youtube.com/embed/FBS1eDpJM5w"));

            peliculas.Add(new Pelicula(44, "AVATAR 3", "../imgs/Avatar3.jpg", "James Cameron", 190, "Sam Worthington, Zoe Saldaña, Sigourney Weaver, Stephen Lang, Kate Winslet, Cliff Curtis",
            "TP", new DateTime(2024, 12, 20),
            "Jake Sully y Neytiri deben proteger a su familia cuando una antigua amenaza reaparece, poniendo en peligro todo lo que aman. La aventura en Pandora continúa con emocionantes descubrimientos y desafíos.",
            1,"Aventura", "https://www.youtube.com/embed/YXtWPVFk5TQ"));

            peliculas.Add(new Pelicula(45, "SPIDER-MAN: ATRAVES DEL MULTIVERSO", "../imgs/SpiderBeyond.jpg", "Joaquim Dos Santos", 130, "Shameik Moore, Hailee Steinfeld, Oscar Isaac, Issa Rae, Jake Johnson, Daniel Kaluuya",
            "+7", new DateTime(2025, 5, 10),
            "Miles Morales se embarca en una nueva aventura en el multiverso, enfrentándose a desafíos y aliados inesperados, en una misión que no solo pondrá en peligro su vida, sino el destino de todos los universos conocidos.",
            1,"Animación", "https://www.youtube.com/embed/b_yMOiRgMmQ"));

        }
        public static List<Pelicula> GetPeliculas()
        {
            return peliculas;
        }



    }
}
