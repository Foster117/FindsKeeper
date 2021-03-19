using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Model.Database
{
    public class ContextInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        protected override void Seed(AppDbContext db)
        {
            db.Materials.Add(new Material { MaterialName = "Медь" });
            db.Materials.Add(new Material { MaterialName = "Серебро" });
            db.Materials.Add(new Material { MaterialName = "Бронза" });
            db.Materials.Add(new Material { MaterialName = "Олово" });
            db.Materials.Add(new Material { MaterialName = "Железо" });
            db.Materials.Add(new Material { MaterialName = "Золото" });
            db.Materials.Add(new Material { MaterialName = "Медно-никелевый сплав" });
            db.Materials.Add(new Material { MaterialName = "Медно-цинковый сплав" });
            db.Materials.Add(new Material { MaterialName = "Другой" });

            db.Periods.Add(new Period { PeriodName = "Российская Империя" });
            db.Periods.Add(new Period { PeriodName = "СССР" });
            db.Periods.Add(new Period { PeriodName = "Польское Королевство" });
            db.Periods.Add(new Period { PeriodName = "Киевская Русь" });
            db.Periods.Add(new Period { PeriodName = "Черняховская Культура" });
            db.Periods.Add(new Period { PeriodName = "Ранний Железный Век" });
            db.Periods.Add(new Period { PeriodName = "Римская Империя" });
            db.Periods.Add(new Period { PeriodName = "Скифы" });
            db.Periods.Add(new Period { PeriodName = "Другой" });

            db.Users.Add(new User() { Name = "Foster117", Password = "qwerty" });

            db.SaveChanges();

            db.Finds.Add(new Find { Name = "5 рублей 1898", MaterialId = 6, PeriodId = 1, OwnerId = 1, UploadDate = DateTime.Now, Description = "5 рублей, Николай II" }); ;
            db.Finds.Add(new Find { Name = "Крестик", MaterialId = 3, PeriodId = 4, OwnerId = 1, UploadDate = DateTime.Now, Description = "Место находки: Киевская обл." });
            db.Finds.Add(new Find { Name = "Наконечник", MaterialId = 1, PeriodId = 2, OwnerId = 1, UploadDate = DateTime.Now, Description = "Наконечник типа 'Семечка'" });

            db.SaveChanges();
        }
    }
}
