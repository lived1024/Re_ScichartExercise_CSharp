using SciChart.Charting.Model.ChartSeries;
using SciChart.Charting.Model.DataSeries;
using SciChart.Data.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace MultiSeries
{
    class MainViewModel : BindableObject
    {
        private string chartTilte = "차트 이름";
        private string xAxisTitle = "X축";
        private string yAxisTitle = "Y축";

        private ObservableCollection<IRenderableSeriesViewModel> renderableSeries;

        #region Getter and Setter
        public ObservableCollection<IRenderableSeriesViewModel> RenderableSeries
        {
            get => renderableSeries;
            set
            {
                renderableSeries = value;
                OnPropertyChanged("RenderableSeries");
            }
        }

        public string ChartTitle
        {
            get => chartTilte;
            set
            {
                chartTilte = value;
                OnPropertyChanged("ChartTitle");
            }
        }

        public string XAxisTitle
        {
            get => xAxisTitle;
            set
            {
                xAxisTitle = value;
                OnPropertyChanged("XAxisTitle");
            }
        }
        public string YAxisTitle
        {
            get => yAxisTitle;
            set
            {
                yAxisTitle = value;
                OnPropertyChanged("YAxisTitle");
            }
        }
        #endregion

        #region Zoom and Pan
        private bool _enableZoom = true;
        public bool EnableZoom
        {
            get { return _enableZoom; }
            set
            {
                if (_enableZoom != value)
                {
                    _enableZoom = value;
                    OnPropertyChanged("EnableZoom");
                    if (_enableZoom) EnablePan = false;
                }
            }
        }
        private bool _enablePan;
        public bool EnablePan
        {
            get { return _enablePan; }
            set
            {
                if (_enablePan != value)
                {
                    _enablePan = value;
                    OnPropertyChanged("EnablePan");
                    if (_enablePan) EnableZoom = false;
                }
            }
        }
        #endregion

        public MainViewModel()
        {
            string json = GetJsonString.Request_Json();
            List<double[]> originList = TransJson.JsonObjectToList(json);
            XyDataSeries<int, double> firstSeries = new XyDataSeries<int, double>() { SeriesName = "First Series" };
            renderableSeries = new ObservableCollection<IRenderableSeriesViewModel>();

            /*for (int i = 0; i < originList.Count; i++ )
            {
                XyDataSeries<int, double> dataSeries = new XyDataSeries<int, double>() { SeriesName = "Series " + (i + 1) };

                double[] values = originList[i];
                int[] count = new int[values.Length];

                for(int j = 0; j < values.Length; j++)
                {
                    count[j] = j;
                    if (values[j] == 0)
                    {
                        values[j] = double.NaN;
                    }
                }

                dataSeries.Append(count, values);
                RenderableSeries.Add(new LineRenderableSeriesViewModel()
                {
                    StrokeThickness = 2,
                    Stroke = Colors.Red,
                    DataSeries = dataSeries
                });
            }*/


            XyDataSeries<int, double> dataSeries = new XyDataSeries<int, double>() { SeriesName = "First Series" };
            int[] count = new int[originList[0].Length];
            double[] values = originList[0];
            for(int i = 0; i < count.Length; i++)
            {
                count[i] = i + 1;
            }
            dataSeries.Append(count, values);

            RenderableSeries.Add(new LineRenderableSeriesViewModel()
            {
                StrokeThickness = 2,
                Stroke = Colors.Red,
                DataSeries = dataSeries,
                StyleKey = "LineSeriesStyle"
            });
        }
    }
}
