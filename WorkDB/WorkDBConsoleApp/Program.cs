using Data.Models;
using Data.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WorkDBConsoleApp {
    class Program {
        static void Main(string[] args) {
            string key = string.Empty;
            do {
                using (UnitOfWork unitOfWork = new UnitOfWork(new MyAppContext())) {
                    key = string.Empty;
                    Console.Clear();
                    IEnumerable<Category> categories = unitOfWork.Category.GetMany(g => true);
                    Console.WriteLine("Категории:");
                    foreach (var categoryDB in categories) {
                        Console.WriteLine($"{categoryDB.Id} - {categoryDB.Name}");
                    }
                    Console.WriteLine("Введите номер для просмотра объявлений в категории (q - для выхода, n - для создания нового объявления, u - отобразить список пользователей):");
                    key = Console.ReadLine();
                    if (int.TryParse(key, out int resultCategory)) {
                        GetAds(g => g.CategoryId == resultCategory);
                        Console.WriteLine("Введите номер для просмотра деталей:");
                        key = Console.ReadLine();
                        if (int.TryParse(key, out int resultAd)) {
                            Ad ad = unitOfWork.Ad.Get(resultAd);
                            Console.WriteLine($"{ad.Title}{Environment.NewLine}{ad.Description}");
                            Console.ReadLine();
                        } else if (key != "q") {
                            Console.WriteLine("Неверные данные!");
                        }
                    } else
                        switch (key) {
                            case "n": {
                                    CreateAd(null);
                                }
                                break;
                            case "u": {
                                    Console.Clear();
                                    IEnumerable<User> users = unitOfWork.User.GetMany(g => true);
                                    foreach (var userDB in users) {
                                        Console.WriteLine($"{userDB.Id} - {userDB.FullName}");
                                        Console.WriteLine("Объявления:");
                                        GetAds(g => g.UserId == userDB.Id);
                                        Console.WriteLine();
                                    }
                                    Console.WriteLine("Введите номер пользователя для добавления ему объявления: ");
                                    key = Console.ReadLine();
                                    if (int.TryParse(key, out int resultUser)) {
                                        CreateAd(unitOfWork.User.Get(resultUser));
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                }
            } while (key != "q");
        }

        public static void GetAds(Expression<Func<Ad, bool>> predicate) {
            using (UnitOfWork unitOfWork = new UnitOfWork(new MyAppContext())) {
                List<Ad> ads = unitOfWork.Ad.GetMany(predicate).ToList();
                foreach (var adDB in ads) {
                    Category category = unitOfWork.Category.Get(adDB.CategoryId);
                    Console.WriteLine($"{adDB.Id} - {category.Name} - {adDB.Title}");
                }
            }
        }

        public static void CreateAd(User user) {
            using (UnitOfWork unitOfWork = new UnitOfWork(new MyAppContext())) {
                string fullName = string.Empty;
                if (user == null) {
                    Console.Write("Введите имя:");
                    fullName = Console.ReadLine();
                } else {
                    fullName = user.FullName;
                }

                Console.Write("Введите название категории (если её нет, она будет создана):");
                string catName = Console.ReadLine();

                Console.Write("Введите заголовок объявления:");
                string title = Console.ReadLine();

                Console.Write("Введите описание объявления:");
                string description = Console.ReadLine();

                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(catName) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description)) {
                    Console.WriteLine("Все данные обязательны для заполнения!");
                    return;
                } else {
                    Category category = unitOfWork.Category.Get(g => g.Name.ToLower() == catName.ToLower());
                    if (category == null) {
                        category = new Category { Name = catName };
                    }
                    if (user == null) {
                        user = new User {
                            FullName = fullName,
                            Ads = new List<Ad> {
                                new Ad {
                                    Category=category,
                                    Title=title,
                                    Description=description
                                }
                            }
                        };
                        unitOfWork.User.Create(user);
                    } else {
                        Ad ad = new Ad {
                            Category = category,
                            Title = title,
                            Description = description,
                            UserId = user.Id
                        };
                        unitOfWork.Ad.Create(ad);
                    }
                    unitOfWork.Save();
                }
            }
        }
    }
}
