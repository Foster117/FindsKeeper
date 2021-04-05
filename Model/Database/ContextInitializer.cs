using Model.Database.Models;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Model.Database
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext db)
        {
            IImageRepository ir = new ImageRepository();

            db.Materials.Add(new Material { Name = "Медь" });
            db.Materials.Add(new Material { Name = "Серебро" });
            db.Materials.Add(new Material { Name = "Бронза" });
            db.Materials.Add(new Material { Name = "Олово" });
            db.Materials.Add(new Material { Name = "Железо" });
            db.Materials.Add(new Material { Name = "Золото" });
            db.Materials.Add(new Material { Name = "Медно-никелевый сплав" });
            db.Materials.Add(new Material { Name = "Медно-цинковый сплав" });
            db.Materials.Add(new Material { Name = "Другой" });

            db.Periods.Add(new Period { Name = "Российская Империя" });
            db.Periods.Add(new Period { Name = "СССР" });
            db.Periods.Add(new Period { Name = "Польское Королевство" });
            db.Periods.Add(new Period { Name = "Киевская Русь" });
            db.Periods.Add(new Period { Name = "Черняховская Культура" });
            db.Periods.Add(new Period { Name = "Ранний Железный Век" });
            db.Periods.Add(new Period { Name = "Римская Империя" });
            db.Periods.Add(new Period { Name = "Скифы" });
            db.Periods.Add(new Period { Name = "Другой" });

            db.Users.Add(new User() { Name = "Foster117", Password = "AK9nU0aKRgFjO89TDAvrvD7SWVjrTiXp3ldNp3mlLgknF3+vjxRCK/NZOCberCkljQ==" });

            db.SaveChanges();

            db.Finds.Add(new Find { Preview = new FindImage() { ImageData = ir.MakeFindPreview(Environment.CurrentDirectory + "/Init_Pics/IMG_E2037.JPG") }, Name = "5 рублей 1898", MaterialId = 6, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "5 рублей, Николай II 5 рублей, Николай II 5 рублей, Николай II 5 рублей, Николай II 5 рублей, Николай II 5 рублей, Николай II 5 рублей, Николай II", 
                Images = new List<FindImage> { 
                new FindImage(){ ImageData = ir.MakeFindImage(Environment.CurrentDirectory + "/Init_Pics/IMG_E2037.JPG") },
                new FindImage(){ ImageData = ir.MakeFindImage(Environment.CurrentDirectory + "/Init_Pics/IMG_2033.JPG") },
                new FindImage(){ ImageData = ir.MakeFindImage(Environment.CurrentDirectory + "/Init_Pics/IMG_2034.JPG") },
            } }); ;
            db.Finds.Add(new Find { Preview = new FindImage() { ImageData = ir.MakeFindPreview(Environment.CurrentDirectory + "/Init_Pics/IMG_E2411.JPG") }, Name = "Деньга", MaterialId = 1, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Место находки: Киевская обл. 1737г." });
            db.Finds.Add(new Find { Preview = new FindImage() { ImageData = ir.MakeFindPreview(Environment.CurrentDirectory + "/Init_Pics/3.jpg") }, Name = "Наконечник", MaterialId = 3, PeriodId = 8, UserId = 1, UploadDate = DateTime.Now, Description = "Наконечник типа 'Семечка'" });
            db.Finds.Add(new Find { Preview = new FindImage() { ImageData = ir.MakeFindPreview(Environment.CurrentDirectory + "/Init_Pics/4.jpg") }, Name = "Шумящая привеска", MaterialId = 3, PeriodId = 4, UserId = 1, UploadDate = DateTime.Now, Description = "Возраст около 1000 лет" }); ;
            db.Finds.Add(new Find { Preview = new FindImage() { ImageData = ir.MakeFindPreview(Environment.CurrentDirectory + "/Init_Pics/5.jpg") }, Name = "Фибула", MaterialId = 3, PeriodId = 5, UserId = 1, UploadDate = DateTime.Now, Description = "Место находки: Черниговская обл." });
            db.Finds.Add(new Find { Preview = new FindImage() { ImageData = ir.MakeFindPreview(Environment.CurrentDirectory + "/Init_Pics/6.jpg") }, Name = "5 коп 1935", MaterialId = 7, PeriodId = 2, UserId = 1, UploadDate = DateTime.Now, Description = "Редкая разновидность" });
            db.Finds.Add(new Find { Preview = new FindImage() { ImageData = ir.MakeFindPreview(Environment.CurrentDirectory + "/Init_Pics/7.jpg") }, Name = "Пол копейки", MaterialId = 1, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Николай II" }); ;
            db.Finds.Add(new Find { Preview = new FindImage() { ImageData = ir.MakeFindPreview(Environment.CurrentDirectory + "/Init_Pics/8.jpg") }, Name = "1 копейка", MaterialId = 1, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Павловская копейка. Место находки: Киев" });
            db.Finds.Add(new Find { Name = "Солид", MaterialId = 2, PeriodId = 3, UserId = 1, UploadDate = DateTime.Now, Description = "Солид Сегезмунда III, 1630-е года" });
            db.Finds.Add(new Find { Preview = new FindImage(), Name = "Полторак", MaterialId = 2, PeriodId = 3, UserId = 1, UploadDate = DateTime.Now, Description = "Место находки: Киевская обл." }); ;
            db.Finds.Add(new Find { Name = "Денарий", MaterialId = 2, PeriodId = 7, UserId = 1, UploadDate = DateTime.Now, Description = "Динарий Антонин Пий 520-535г" });
            db.Finds.Add(new Find { Name = "Вислая печать", MaterialId = 4, PeriodId = 4, UserId = 1, UploadDate = DateTime.Now, Description = "Целая вислая печать. Место находки: Житомирская обл." });
            db.Finds.Add(new Find { Name = "Лезвие Ножа", MaterialId = 5, PeriodId = 6, UserId = 1, UploadDate = DateTime.Now, Description = "Остатки лезвия ножа, возраст около 3200 лет" }); ;
            db.Finds.Add(new Find { Name = "5 копеек", MaterialId = 1, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Катькин пятак" });
            db.Finds.Add(new Find { Name = "Наконечник копья", MaterialId = 5, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Копейный наконечник, 17 век" });
            db.Finds.Add(new Find { Name = "Кольцо", MaterialId = 1, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Кольцо с рисунком 'Роза ветров'" }); ;
            db.Finds.Add(new Find { Name = "Полковой знак", MaterialId = 9, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Лейб-гвардии Гренадерский полк, 1909 года" });
            db.Finds.Add(new Find { Name = "Каска", MaterialId = 5, PeriodId = 2, UserId = 1, UploadDate = DateTime.Now, Description = "Каска советского солдата. Пулевое отверстие с фронтальной стороны" });
            //
            db.Finds.Add(new Find { Name = "5 рублей 1898", MaterialId = 6, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "5 рублей, Николай II" }); ;
            db.Finds.Add(new Find { Name = "Крестик", MaterialId = 3, PeriodId = 4, UserId = 1, UploadDate = DateTime.Now, Description = "Место находки: Киевская обл." });
            db.Finds.Add(new Find { Name = "Наконечник", MaterialId = 3, PeriodId = 8, UserId = 1, UploadDate = DateTime.Now, Description = "Наконечник типа 'Семечка'" });
            db.Finds.Add(new Find { Name = "Шумящая привеска", MaterialId = 3, PeriodId = 4, UserId = 1, UploadDate = DateTime.Now, Description = "Возраст около 1000 лет" }); ;
            db.Finds.Add(new Find { Name = "Фибула", MaterialId = 3, PeriodId = 5, UserId = 1, UploadDate = DateTime.Now, Description = "Место находки: Черниговская обл." });
            db.Finds.Add(new Find { Name = "5 коп 1935", MaterialId = 7, PeriodId = 2, UserId = 1, UploadDate = DateTime.Now, Description = "Редкая разновидность" });
            db.Finds.Add(new Find { Name = "Пол копейки", MaterialId = 1, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Николай II" }); ;
            db.Finds.Add(new Find { Name = "1 копейка", MaterialId = 1, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Павловская копейка. Место находки: Киев" });
            db.Finds.Add(new Find { Name = "Солид", MaterialId = 2, PeriodId = 3, UserId = 1, UploadDate = DateTime.Now, Description = "Солид Сегезмунда III, 1630-е года" });
            db.Finds.Add(new Find { Name = "Полторак", MaterialId = 2, PeriodId = 3, UserId = 1, UploadDate = DateTime.Now, Description = "Место находки: Киевская обл." }); ;
            db.Finds.Add(new Find { Name = "Денарий", MaterialId = 2, PeriodId = 7, UserId = 1, UploadDate = DateTime.Now, Description = "Динарий Антонин Пий 520-535г" });
            db.Finds.Add(new Find { Name = "Вислая печать", MaterialId = 4, PeriodId = 4, UserId = 1, UploadDate = DateTime.Now, Description = "Целая вислая печать. Место находки: Житомирская обл." });
            db.Finds.Add(new Find { Name = "Лезвие Ножа", MaterialId = 5, PeriodId = 6, UserId = 1, UploadDate = DateTime.Now, Description = "Остатки лезвия ножа, возраст около 3200 лет" }); ;
            db.Finds.Add(new Find { Name = "5 копеек", MaterialId = 1, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Катькин пятак" });
            db.Finds.Add(new Find { Name = "Наконечник копья", MaterialId = 5, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Копейный наконечник, 17 век" });
            db.Finds.Add(new Find { Name = "Кольцо", MaterialId = 1, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Кольцо с рисунком 'Роза ветров'" }); ;
            db.Finds.Add(new Find { Name = "Полковой знак", MaterialId = 9, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Лейб-гвардии Гренадерский полк, 1909 года" });
            db.Finds.Add(new Find { Name = "Каска", MaterialId = 5, PeriodId = 2, UserId = 1, UploadDate = DateTime.Now, Description = "Каска советского солдата. Пулевое отверстие с фронтальной стороны" });
            db.Finds.Add(new Find { Name = "5 коп 1935", MaterialId = 7, PeriodId = 2, UserId = 1, UploadDate = DateTime.Now, Description = "Редкая разновидность" });
            db.Finds.Add(new Find { Name = "Пол копейки", MaterialId = 1, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Николай II" }); ;
            db.Finds.Add(new Find { Name = "1 копейка", MaterialId = 1, PeriodId = 1, UserId = 1, UploadDate = DateTime.Now, Description = "Павловская копейка. Место находки: Киев" });
            db.Finds.Add(new Find { Name = "Солид", MaterialId = 2, PeriodId = 3, UserId = 1, UploadDate = DateTime.Now, Description = "Солид Сегезмунда III, 1630-е года" });
            db.Finds.Add(new Find { Name = "Солид", MaterialId = 2, PeriodId = 3, UserId = 1, UploadDate = DateTime.Now, Description = "Солид Сегезмунда III, 1630-е года" });

            db.SaveChanges();
        }
    }
}
