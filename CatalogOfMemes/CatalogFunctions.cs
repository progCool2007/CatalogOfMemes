using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace CatalogOfMemes
{
    public class CatalogFunctions
    {
        List<Joke> jokes = new List<Joke>();
        

        public void SaveJokes()
        {
            var serializer = new XmlSerializer(typeof(List<Joke>));
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, jokes);
                File.WriteAllText("jokes.xml", writer.ToString());
            }
        }
        public void LoadJokes()
        {
            var xml = File.ReadAllText("jokes.xml");
            var serializer = new XmlSerializer(typeof(List<Joke>));
            using (var reader = new StringReader(xml))
            {
                jokes = (List<Joke>)serializer.Deserialize(reader);
            }
        }
        public void UpdateJokeList(ListBox lb_joke)
        {
            lb_joke.Items.Clear();
            foreach (var joke in jokes)
            {
                lb_joke.Items.Add(joke.Name);
            }
        }

        public void SaveJokeURL(TextBox tbName, TextBox tbURL, ComboBox cb_category)
        {
            LoadJokes();
            var joke = new Joke
            {
                Name = tbName.Text,
                Type = cb_category.Text,
            };
            joke.ImageLocation = tbURL.Text;
            jokes.Add(joke);
            SaveJokes();
        }
        public void SaveJokePC(TextBox tbName, TextBox tbURL, ComboBox cb_category)
        {
            LoadJokes();
            var joke = new Joke
            {
                Name = tbName.Text,
                Type = cb_category.Text,
            };
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                joke.ImageLocation = openFileDialog.FileName;
            }
            jokes.Add(joke);
            SaveJokes();
        }

        public void DeleteJoke(ListBox lb_joke)
        {
            var selectedMeme = jokes.FirstOrDefault(joke => joke.Name == (string)lb_joke.SelectedItem);
            if (selectedMeme != null)
            {
                jokes.Remove(selectedMeme);
                UpdateJokeList(lb_joke);
            }
            SaveJokes();
        }

        public void ChangeSelectedJoke(ListBox lb_joke, Image ImageMem)
        {
            var selectedMeme = jokes.FirstOrDefault(joke => joke.Name == (string)lb_joke.SelectedItem);
            if (selectedMeme != null)
            {
                ImageMem.Source = new BitmapImage(new Uri(selectedMeme.ImageLocation));
            }
        }

        public void SortJoke(ListBox lb_joke, ComboBox ComboBoxCategory)
        {
            if(ComboBoxCategory.SelectedIndex == 0)
            {
                LoadJokes();
                UpdateJokeList(lb_joke);
            }
            else
            {
                var category = (ComboBoxCategory.SelectedItem as ComboBoxItem).Content.ToString();
                var filteredMemes = jokes.Where(joke => joke.Type == category).ToList();
                lb_joke.Items.Clear();
                foreach (var joke in filteredMemes)
                {
                    lb_joke.Items.Add(joke.Name);
                }
            }           
        }
        public void SearchJoke(ListBox lb_joke, TextBox tbSearch)
        {
            var searchText = tbSearch.Text.ToLower();
            var filteredMemes = jokes.Where(joke => joke.Name.ToLower().Contains(searchText)).ToList();
            lb_joke.Items.Clear();
            foreach (var joke in filteredMemes)
            {
                lb_joke.Items.Add(joke.Name);
            }
        }
    }
}
