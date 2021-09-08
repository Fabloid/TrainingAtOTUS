using Data.Models;
using Data.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkDBConsoleApp.Interface;

namespace WorkDBConsoleApp.Presenter {
    public class ProgramPresenter {
        private IMyInterface _myInterface;
        public ProgramPresenter(IMyInterface myInterface) {
            _myInterface = myInterface;
            WorkProgram();
        }

        private void WorkProgram() {
            string key = string.Empty;
            do {
                using (UnitOfWork unitOfWork = new UnitOfWork(new MyAppContext())) {
                    key = string.Empty;
                    _myInterface.ClearWindow();
                    IEnumerable<Category> categories = unitOfWork.Category.GetMany(g => true);
                    _myInterface.ShowMessage = "Категории:";
                    foreach (var categoryDB in categories) {
                        _myInterface.ShowMessage = $"{categoryDB.Id} - {categoryDB.Name}";
                    }
                    _myInterface.ShowMessage = "Введите номер для просмотра объявлений в категории (q - для выхода, n - для создания нового объявления, u - отобразить список пользователей):";
                    key = _myInterface.GetEnterData;
                    if (int.TryParse(key, out int resultCategory)) {
                        GetAds(g => g.CategoryId == resultCategory);
                        _myInterface.ShowMessage = "Введите номер для просмотра деталей:";
                        key = _myInterface.GetEnterData;
                        if (int.TryParse(key, out int resultAd)) {
                            Ad ad = unitOfWork.Ad.Get(resultAd);
                            _myInterface.ShowMessage = $"{ad.Title}{Environment.NewLine}{ad.Description}";
                            _ = _myInterface.GetEnterData;
                        } else if (key != "q") {
                            _myInterface.ShowMessage = "Неверные данные!";
                        }
                    } else
                        switch (key) {
                            case "n": {
                                    CreateAd(null);
                                }
                                break;
                            case "u": {
                                    _myInterface.ClearWindow();
                                    IEnumerable<User> users = unitOfWork.User.GetMany(g => true);
                                    foreach (var userDB in users) {
                                        _myInterface.ShowMessage = $"{userDB.Id} - {userDB.FullName}";
                                        _myInterface.ShowMessage = "Объявления:";
                                        GetAds(g => g.UserId == userDB.Id);
                                        _myInterface.ShowMessage = string.Empty;
                                    }
                                    _myInterface.ShowMessage = "Введите номер пользователя для добавления ему объявления: ";
                                    key = _myInterface.GetEnterData;
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

        private void GetAds(Expression<Func<Ad, bool>> predicate) {
            using (UnitOfWork unitOfWork = new UnitOfWork(new MyAppContext())) {
                List<Ad> ads = unitOfWork.Ad.GetMany(predicate).ToList();
                foreach (var adDB in ads) {
                    Category category = unitOfWork.Category.Get(adDB.CategoryId);
                    _myInterface.ShowMessage = $"{adDB.Id} - {category.Name} - {adDB.Title}";
                }
            }
        }

        private void CreateAd(User user) {
            using (UnitOfWork unitOfWork = new UnitOfWork(new MyAppContext())) {
                DataForCreateAd(user, out string fullName, out string catName, out string title, out string description);

                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(catName) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description)) {
                    _myInterface.ShowMessage = "Все данные обязательны для заполнения!";
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

        private void DataForCreateAd(User user, out string fullName, out string catName, out string title, out string description) {
            if (user == null) {
                _myInterface.ShowMessage = "Введите имя:";
                fullName = _myInterface.GetEnterData;
            } else {
                fullName = user.FullName;
            }

            _myInterface.ShowMessage = "Введите название категории (если её нет, она будет создана):";
            catName = _myInterface.GetEnterData;

            _myInterface.ShowMessage = "Введите заголовок объявления:";
            title = _myInterface.GetEnterData;

            _myInterface.ShowMessage = "Введите описание объявления:";
            description = _myInterface.GetEnterData;
        }
    }
}
