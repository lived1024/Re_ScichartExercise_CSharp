/*using SciChart.Charting.Model.DataSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSeries
{
    public class MakeDataSeries
    {
        private static MakeDataSeries instance = null;
        public static MakeDataSeries Instance()
        {
            if (instance == null)
            {
                instance = new MakeDataSeries();
            }
            return instance;
        }

        private List<String> allKeyList = new List<string>();
        public List<String> AllKeyList { get => allKeyList; set => allKeyList = value; }

        private MakeDataSeries()
        {
        }

        public static List<XyDataSeries<int, double>> ToDataSeriesFromList()
        {
            this.allKeyList.Clear();

            string json = GetJsonString.Request_Json();
            List<double[]> originalList = TransJson.JsonObjectToList(json);
            List<XyDataSeries<int, double>> datsSeriesList = new List<XyDataSeries<int, double>>();

            return null;
        }


        public List<List<XyDataSeries<int, double>>> ToDataSeriesListFromList()
        {
            this.allKeyList.Clear();

            string json = GetJsonString.Request_Json();
            List<Dictionary<String, double[]>> dictionaryList = TransJson.JsonToList(json);

            List<List<XyDataSeries<int, double>>> allDataSeriesList = new List<List<XyDataSeries<int, double>>>();

            for (int i = 0; i < dictionaryList.Count; i++)
            {
                Dictionary<String, double[]> originDictionary = dictionaryList[i];
                List<String> keyList = new List<string>(originDictionary.Keys);
                List<XyDataSeries<int, double>> childList = new List<XyDataSeries<int, double>>();

                for (int j = 0; j < keyList.Count; j++)
                {
                    XyDataSeries<int, double> dataSeries = new XyDataSeries<int, double>();
                    dataSeries.AcceptsUnsortedData = true;
                    double[] values = originDictionary[keyList[j]];
                    int[] count = new int[values.Length];

                    for (int k = 0; k < values.Length; k++)
                    {
                        count[k] = k;
                        if (values[k] == 0)
                        {
                            values[k] = double.NaN;
                        }
                    }
                    dataSeries.Append(count, values);
                    dataSeries.Insert(1, 1, 15);
                    childList.Add(dataSeries);
                }
                this.AllKeyList.Add(keyList);
                allDataSeriesList.Add(childList);
            }

            return allDataSeriesList;
        }

        public List<List<XyDataSeries<int, double>>> ToDataSeriesListFromDictionary()
        {
            this.allKeyList = null;
            this.allKeyDictionary.Clear();

            string json = GetJsonString.Request_Json();
            Dictionary<String, Dictionary<String, double[]>> dictionaryWrapper = TransJson.JsonToDictionary(json);

            List<List<XyDataSeries<int, double>>> allDataSeriesList = new List<List<XyDataSeries<int, double>>>();

            List<String> wrapperKeyList = new List<string>(dictionaryWrapper.Keys);

            for (int i = 0; i < dictionaryWrapper.Count; i++)
            {
                Dictionary<String, double[]> originDictionary = dictionaryWrapper[wrapperKeyList[i]];
                List<String> keyList = new List<string>(originDictionary.Keys);
                List<XyDataSeries<int, double>> childList = new List<XyDataSeries<int, double>>();

                for (int j = 0; j < keyList.Count; j++)
                {
                    XyDataSeries<int, double> dataSeries = new XyDataSeries<int, double>();

                    double[] values = originDictionary[keyList[j]];
                    int[] count = new int[values.Length];

                    for (int k = 0; k < values.Length; k++)
                    {
                        count[k] = k;
                        if (values[k] == 0)
                        {
                            values[k] = double.NaN;
                        }
                    }

                    dataSeries.Append(count, values);
                    childList.Add(dataSeries);
                }
                this.AllKeyDictionary.Add(wrapperKeyList[i], keyList);
                allDataSeriesList.Add(childList);
            }

            return allDataSeriesList;
        }
    }
}
*/