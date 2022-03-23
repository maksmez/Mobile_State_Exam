using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using SkiaSharp;
using Entry = Microcharts.ChartEntry;
using System.Collections.ObjectModel;

namespace Mobile_State_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistic : ContentPage
    {
        Science science = new Science();
        Theme theme = new Theme();
        ObservableCollection<Theme> theme_list;
        ObservableCollection<Exam> exam_list;
        Exam exam = new Exam();
        public Statistic()
        {
            InitializeComponent();
            var comfort = (from g in science.LoadData() select g.name).Distinct();
            var a = comfort;
            picker.ItemsSource = comfort.ToList();
            picker.SelectedItem = comfort.First();
        }

        async private void Go_to_SectionPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async private void Go_to_Statistic_item_test(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Statistic_item_test(theme_list));
        }

        async private void Go_to_Statistic_item_exam(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Statistic_item_exam(exam_list));
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sciene_id = 0;
            double count_passed = 0;
            double count_wrong = 0;
            double count_none = 0;
            foreach (var item in science.LoadData().Where(x => x.name == picker.SelectedItem.ToString()).ToList())
            {
                sciene_id = item.id;
            }
            theme_list = theme.LoadData(sciene_id);
            foreach (var item in theme_list.ToList())
            {
                if (item.total_score < 0)
                {
                    count_none++;
                }
                if (item.total_score >= 80)
                {
                    count_passed++;
                }
                if (item.total_score < 80 && item.total_score >= 0)
                {
                    count_wrong++;
                }
            }
            if (theme_list.Count == 0)
            {
                pass.Text = 0 + "%";
                wrong.Text = 100 + "%";
                count_wrong = 100;
            }
            else
            {
                pass.Text = Convert.ToString(Math.Round(count_passed / Convert.ToDouble(theme_list.Count) * 100, 0)) + "%";
                wrong.Text = Convert.ToString(Math.Round(count_wrong / Convert.ToDouble(theme_list.Count) * 100, 0)) + "%";
                none.Text = Convert.ToString(Math.Round(count_none / Convert.ToDouble(theme_list.Count) * 100, 0)) + "%";

            }

            if (count_passed >= count_wrong)
            {
                center_chart1.Text = pass.Text;
                center_chart1.TextColor = Color.FromHex("3BA639");
            }
            if (count_passed <= count_wrong)
            {
                center_chart1.Text = wrong.Text;
                center_chart1.TextColor = Color.FromHex("D02424");
            }
            if (count_none > count_wrong && count_none > count_passed)
            {
                center_chart1.Text = none.Text;
                center_chart1.TextColor = Color.FromHex("F7CC33");
            }

            List<Entry> entries_for_first_donut = new List<Entry>
            {
            new Entry((float)count_passed)
            {
                Color=SKColor.Parse("3BA639"),
            },
            new Entry((float)count_wrong)
            {
                Color = SKColor.Parse("D02424"),
            },
            new Entry((float)count_none)
            {
                Color =  SKColor.Parse("F7CC33"),
            },
            };
            Chart1.Chart = new DonutChart() { Entries = entries_for_first_donut, GraphPosition = GraphPosition.Center };
            double count_passed_exam = 0;
            double count_wrong_exam = 0;
            exam_list = exam.LoadData(sciene_id);

            foreach (var item in exam_list.ToList())
            {
                if (item.total_score >= 80)
                {
                    count_passed_exam++;
                }
                if (item.total_score < 80)
                {
                    count_wrong_exam++;
                }
            }
            if (exam_list.Count == 0)
            {
                exam_pas.Text = 0 + "%";
                exam_wrong.Text = 100 + "%";
                count_wrong_exam = 100;
            }
            else
            {
                exam_pas.Text = Convert.ToString(Math.Round(count_passed_exam / Convert.ToDouble(exam_list.Count) * 100, 0)) + "%";
                exam_wrong.Text = Convert.ToString(Math.Round(count_wrong_exam / Convert.ToDouble(exam_list.Count) * 100, 0)) + "%";
            }


            List<Entry> entries_for_second_donut = new List<Entry>
            {
            new Entry((float)count_passed_exam)
            {
                Color=SKColor.Parse("3BA639"),

            },
            new Entry((float)count_wrong_exam)
            {
                Color = SKColor.Parse("D02424"),
            }
            };
            Chart2.Chart = new DonutChart() { Entries = entries_for_second_donut, GraphPosition = GraphPosition.Center };


            if (count_passed_exam > count_wrong_exam)
            {
                center_chart2.Text = exam_pas.Text;
                center_chart2.TextColor = Color.FromHex("3BA639");
            }
            else
            {
                center_chart2.Text = exam_wrong.Text;
                center_chart2.TextColor = Color.FromHex("D02424");
            }
        }
    }
}