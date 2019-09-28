using DemoAnimations.Messages;
using DemoAnimations.ViewModels.Domain;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoAnimations.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        public MoviesPage()
        {
            InitializeComponent();
            GetMovies();
            BindingContext = this;
        }

        public List<MovieViewModel> Movies { get; set; }

        private void GetMovies()
        {
            

            Movies = new List<MovieViewModel>()
            {
                new MovieViewModel()
                {
                    Name = "Harry Potter: la piedra filosofal",
                    PosterImage = "principal_harry_potter.png",
                    CoverImage = "harry_potter.png",
                    AgeRestriction = "10",
                    Description = "Harry Potter y la piedra filosofal es una película se basa en el libro escrito por J.K. Rowling, muestra la historia de un niño huérfano que no sabe que es un mago hasta cumplir los diez años que recibe una invitación de Hogwarts.",
                    Duration = "1h 30m",
                    Gender = "Aventura"
                },
                new MovieViewModel()
                {
                    Name = "Avengers: Endgame",
                    PosterImage = "principal_avenger.png",
                    CoverImage = "avengers.png",
                    AgeRestriction = "13",
                    Description = "Es una película de superhéroes estadounidense de 2019 basada en el grupo los Vengadores de Marvel Comics, producida por Marvel Studios y distribuida por Walt Disney Studios Motion Pictures. Es una secuela directa de la película de 2018 Avengers: Infinity War y una continuación de The Avengers (2012) y Avengers: Age of Ultron (2015), siendo la vigesimosegunda película del Universo cinematográfico de Marvel (MCU, por sus siglas en inglés).",
                    Duration = "2h 3m",
                    Gender = "Ficción"
                },
                new MovieViewModel()
                {
                    Name = "El Rey león",
                    PosterImage = "peincipal_reyleon.png",
                    CoverImage = "rey_leon.png",
                    AgeRestriction = "7",
                    Description = "El argumento de El rey león se desarrolla en África y tiene inspiraciones en las historias bíblicas de José y Moisés, y en la obra Hamlet de William Shakespeare. Cuenta la historia de Simba, un joven león que tras la muerte de su padre, el rey de la sabana y jefe de La Roca del Rey.",
                    Duration = "1h 58m",
                    Gender = "Infantil"
                },
                new MovieViewModel()
                {
                    Name = "Hombres de negro: Internacional",
                    PosterImage = "principal_hombres_de_negro.png",
                    CoverImage = "hombres_de_negro.png",
                    AgeRestriction = "16",
                    Description = "Los Hombres de negro son agentes especiales que forman parte de una unidad totalmente secreta del gobierno. Su misión consiste en controlar a los alienígenas. Dos de estos agentes descubren a un terrorista galáctico que pretende acabar con la Tierra.",
                    Duration = "2h 10m",
                    Gender = "Ficción"
                },
                new MovieViewModel()
                {
                    Name = "Avatar",
                    PosterImage = "principal_avatar.png",
                    CoverImage = "avatar.png",
                    AgeRestriction = "14",
                    Description = "En un exuberante planeta llamado Pandora viven los Na'vi, seres que aparentan ser primitivos pero que en realidad son muy evolucionados. Debido a que el ambiente de Pandora es venenoso, los híbridos humanos/Na'vi, llamados Avatares, están relacionados con las mentes humanas, lo que les permite moverse libremente por Pandora. Jake Sully, un exinfante de marina paralítico se transforma a través de un Avatar, y se enamora de una mujer Na'vi.",
                    Duration = "3h 20m",
                    Gender = "Aventura"
                },
                new MovieViewModel()
                {
                    Name = "Fast & Furious: Hobbs & Shaw",
                    PosterImage = "principal_rapidosyfuriosos.png",
                    CoverImage = "rapidos_y_furiosos.png",
                    AgeRestriction = "10",
                    Description = "Spin-off de la franquicia cinematográfica 'A todo gas', que sigue al policía estadounidense Hobbs y al mercenario británico Shaw. En el pasado, Hobbs encarceló a Shaw después de que este intentara matarlo. Ahora deben aliarse para combatir al terrorista Brixton, que tiene una fuerza sobrenatural.",
                    Duration = "1h 30m",
                    Gender = "Acción"
                },
                new MovieViewModel()
                {
                    Name = "Titanic",
                    PosterImage = "principal_titanic.png",
                    CoverImage = "titanic.png",
                    AgeRestriction = "17",
                    Description = "Una joven de la alta sociedad abandona a su arrogante pretendiente por un artista humilde en el trasatlántico que se hundió durante su viaje inaugural.",
                    Duration = "1h 40m",
                    Gender = "Drama"
                },
                new MovieViewModel()
                {
                    Name = "Terminator: Dark Fate",
                    PosterImage = "principal_terminator.png",
                    CoverImage = "terminator.png",
                    AgeRestriction = "15",
                    Description = "Sarah Connor une todas sus fuerzas con una mujer cyborg para proteger a una joven de un extremadamente poderoso y nuevo Terminator.",
                    Duration = "2h 10m",
                    Gender = "Ficción"
                },
                new MovieViewModel()
                {
                    Name = "Up: Una aventura de altura",
                    PosterImage = "principal_up.png",
                    CoverImage = "up.png",
                    AgeRestriction = "7",
                    Description = "Up, es una apasionante y entrañable película que nos narra la historia de un viudo que consigue cumplir su sueño y volar con su casa a lugares fascinantes. Contará con la compañía de Russell, un pequeño explorador.",
                    Duration = "1h 20m",
                    Gender = "Infantil"
                },
                new MovieViewModel()
                {
                    Name = "Toy Story 4",
                    PosterImage = "principal_toy_story.png",
                    CoverImage = "toy_story.png",
                    AgeRestriction = "10",
                    Description = "Woody siempre ha tenido claro cuál es su labor en el mundo: cuidar a su dueño, ya sea Andy o Bonnie. Sin embargo, Woody descubrirá lo grande que puede ser el mundo para un juguete cuando el juguete Forky se convierta en su nuevo compañero de habitación. Los juguetes se embarcarán en una aventura que no olvidarán jamás durante un viaje por carretera.",
                    Duration = "1h 40m",
                    Gender = "Infantil"
                }
            };
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new MovieDetailPage(e.Item as MovieViewModel));
        }

        private void ScrollReporterEffect_ScrollChanged(object sender, XFUtils.Effects.ScrollEventArgs args)
        {
            MessagingCenter.Send(new ScrollMessage(), ScrollMessage.ScrollChanged, args.Y);
        }
    }
}