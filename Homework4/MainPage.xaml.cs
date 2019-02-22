using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework4.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Homework4
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Monster> MonsterList;
        ObservableCollection<Monster> DeletedMonsterList = new ObservableCollection<Monster>();
        public MainPage()
        {
            InitializeComponent();
            MakeMonsters();
        }
        private void MakeMonsters()
        {
            MonsterList = new ObservableCollection<Monster>()
            {
                new Monster()
                {
                    ISource = ImageSource.FromFile("phone.json"),
                    MonsterName = "Phone Monster",
                    Description = "Will ask if you have any games on your phone and then play them all.",
                    Difficulty = 1,
                    Health = 100
                },
                new Monster()
                {
                    ISource = ImageSource.FromFile("love.json"),
                    MonsterName = "Love Monster",
                    Description = "Will try to give you love.",
                    Difficulty = 4,
                    Health = 400
                },
                new Monster()
                {
                    ISource = ImageSource.FromFile("fraken.json"),
                    MonsterName = "Fraken Monster",
                    Description = "Made by Mary Shelley.",
                    Difficulty = 8,
                    Health = 800
                },
                new Monster()
                {
                    ISource = ImageSource.FromFile("bat.json"),
                    MonsterName = "Bat Monster",
                    Description = "Like Batman but Monster.",
                    Difficulty = 2,
                    Health = 200
                },
                new Monster()
                {
                    ISource = ImageSource.FromFile("cry.json"),
                    MonsterName = "Cry Monster",
                    Description = "This is Love Monster. You just didn't accept its love.",
                    Difficulty = 6,
                    Health = 600
                },
                new Monster()
                {
                    ISource = ImageSource.FromFile("tri.json"),
                    MonsterName = "Tri Monster",
                    Description = "Theres three of them!!",
                    Difficulty = 3,
                    Health = 300
                },
                new Monster()
                {
                    ISource = ImageSource.FromFile("dance.json"),
                    MonsterName = "Dance Monster",
                    Description = "Will ask you to prom and will just dance, and dance, and dance, and dance, and dance, and dance.",
                    Difficulty = 5,
                    Health = 500
                }
            };
            MonsterListView.ItemsSource = MonsterList;
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Monster mi = (Monster)MonsterListView.SelectedItem;
            int num = MonsterList.IndexOf(MonsterListView.SelectedItem);
            MonsterList.Remove((Monster)MonsterListView.SelectedItem);
            DeletedMonsterList.Add(mi);
        }

        //pull and refresh 
        void Handle_Refreshing(object sender, System.EventArgs e)
        {

            int num = DeletedMonsterList.Count();
            for (int i = 0; num > i; i++)
            {
                MonsterList.Add(DeletedMonsterList[i]);

            }
            // MonsterListView.IsRefreshing = false;

            DeletedMonsterList.Clear();
            MonsterListView.ItemsSource = MonsterList;
            MonsterListView.EndRefresh();
        }
    }
}
