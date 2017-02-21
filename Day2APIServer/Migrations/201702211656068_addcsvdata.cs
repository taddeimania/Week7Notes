namespace Day2APIServer.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Web;

    public partial class addcsvdata : DbMigration
    {
        public override void Up()
        {
            var systemPath = AppDomain.CurrentDomain.BaseDirectory + @"..\App_Data\data.csv";
            var openFile = File.ReadAllLines(systemPath);

            using (var db = new ApplicationContext())
            {
                foreach (string row in openFile)
                {
                    var data = row.Split(',');
                    Cereal newCereal = new Cereal
                    {
                        Name = data[0],
                        Manufacturer = data[1]
                    };
                    db.Cereals.Add(newCereal);
                }
                db.SaveChanges();
            }
            // ------------------ :)
            // throw new Exception("cookies");
        }
        
        public override void Down()
        {
        }
    }
}
