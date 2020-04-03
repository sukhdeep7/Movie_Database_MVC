namespace Movie_Database_MVC.Models
{//A movie cast assigment 
    public class MovieCastAssignment
    {
        //Movie cast asiigment id 
        public int Id { get; set; }

        //Actor id foreign key
        public int ActorId { get; set; }

        //Movie id foreign key
        public int MovieId { get; set; }

        //Actor link
        public Actor Actor { get; set; }

        //Movie link
        public Movie Movie { get; set; }




    }
}
