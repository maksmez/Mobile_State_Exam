using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microcharts;
using SkiaSharp;
using Microcharts.Forms;
using Entry = Microcharts.ChartEntry;

namespace Mobile_State_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistic : ContentPage
    {
        List<Entry> entries_for_first_donut = new List<Entry>
        {
            new Entry(64)
            {
                Color=SKColor.Parse("3BA639"),
                //Label ="January",
                //ValueLabel = "200",
                
            },
            new Entry(30)
            {
                Color = SKColor.Parse("D02424"),
                //Label = "March",
                //ValueLabel = "400"
            },
            new Entry(6)
            {
                Color =  SKColor.Parse("F7CC33"),
                //Label = "Octobar",
                //ValueLabel = "-100"
            },
            };
        List<Entry> entries_for_second_donut = new List<Entry>
        {
            new Entry(30)
            {
                Color=SKColor.Parse("3BA639"),
                //Label ="January",
                //ValueLabel = "200",
                
            },
            new Entry(70)
            {
                Color = SKColor.Parse("D02424"),
                //Label = "March",
                //ValueLabel = "400"
            }
            };

        public Statistic()
        {
            InitializeComponent();
            Chart1.Chart = new DonutChart() { Entries = entries_for_first_donut, GraphPosition = GraphPosition.Center };
            Chart2.Chart = new DonutChart() { Entries = entries_for_second_donut, GraphPosition = GraphPosition.Center };
            int value_test_positive = 60;
            int value_test_negative = 40;
            int value_exam_positive = 10;
            int value_exam_negative = 90;
            if (value_test_positive > value_test_negative)
            {
                center_chart1.Text = Convert.ToString(value_test_positive + "%");
                center_chart1.TextColor = Color.FromHex("3BA639");
            }
            else
            {
                center_chart1.Text = Convert.ToString(value_test_negative + "%");
                center_chart1.TextColor = Color.FromHex("D02424");
            }

            if (value_exam_positive > value_exam_negative)
            {
                center_chart2.Text = Convert.ToString(value_exam_positive + "%");
                center_chart2.TextColor = Color.FromHex("3BA639");
            }
            else
            {
                center_chart2.Text = Convert.ToString(value_exam_negative + "%");
                center_chart2.TextColor = Color.FromHex("D02424");
            }
        }

        async private void Go_to_SectionPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

       async private void Go_to_Statistic_item_test(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Statistic_item_test());
        }

       async private void Go_to_Statistic_item_exam(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Statistic_item_exam());

        }
    }
}