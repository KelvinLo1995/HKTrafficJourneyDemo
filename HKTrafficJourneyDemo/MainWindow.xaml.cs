using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.IO;
using System.Windows.Threading;
using System.Xml.Serialization;
using System.ComponentModel;

namespace HKTrafficJourneyDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// ticker for refresh data
        /// </summary>
        private DispatcherTimer _dispatcherTimer;

        /// <summary>
        /// all the raw data from xml
        /// </summary>
        private jtis_journey_list journeryData = new jtis_journey_list();

        /// <summary>
        /// filter data to be shown in dg
        /// </summary>
        private jtis_journey_list fileredJourneryData = new jtis_journey_list();

        public MainWindow()
        {
            InitializeComponent();
            
            InitWebClient();

            UpdateJounery();

            SetJouneryDataFilter();

            _dispatcherTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(10)
            };
            _dispatcherTimer.Tick += OnTimer;
            _dispatcherTimer.Start();
        }

        private void OnTimer(object source, EventArgs e)
        {
            UpdateJounery();
            RefreshJouneryData();
        }

        private void InitWebClient()
        {
            ServicePointManager.SecurityProtocol =
                    (SecurityProtocolType)3072 | // TLS 1.2
                    (SecurityProtocolType)768 | // TLS 1.1
                    (SecurityProtocolType)192;   // TLS 1.0
        }

        private List<string> destinationList = new List<string>();

        /// <summary>
        /// Get data refresh
        /// </summary>
        private void UpdateJounery()
        {
            if (journeryData.jtis_journey_time != null)
                journeryData.jtis_journey_time.Clear();

            var request = WebRequest.Create("https://resource.data.one.gov.hk/td/jss/Journeytimev2.xml");
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var reader = new StreamReader(webStream);
            string data = reader.ReadToEnd();

            TextReader rd = new StringReader(data);
            XmlSerializer serializer = new XmlSerializer(typeof(jtis_journey_list));
            journeryData = (jtis_journey_list)serializer.Deserialize(rd);

            if (destinationList.Count == 0)
            {
                foreach (jtis_journey_listJtis_journey_time jd in journeryData.jtis_journey_time)
                {
                    if (!destinationList.Contains(jd.DESTINATION_ID))
                    {
                        destinationList.Add(jd.DESTINATION_ID);
                    }
                }

                cbDestinationFilter.ItemsSource = null;
                cbDestinationFilter.ItemsSource = destinationList;
            }
        }

        /// <summary>
        /// refresh data
        /// </summary>
        private void RefreshJouneryData()
        {
            SetJouneryDataFilter(desFilter);
        }

        /// <summary>
        /// util to sort data grid by column
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="columnIndex"></param>
        /// <param name="sortDirection"></param>
        private static void SortDataGrid(DataGrid dataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Ascending)
        {
            var column = dataGrid.Columns[columnIndex];
            dataGrid.Items.SortDescriptions.Clear();
            dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));
            foreach (var col in dataGrid.Columns)
            {
                col.SortDirection = null;
            }
            column.SortDirection = sortDirection;
            dataGrid.Items.Refresh();
        }

        /// <summary>
        /// jounery filter implement
        /// </summary>
        /// <param name="filter"></param>
        private void SetJouneryDataFilter(string filter = "")
        {
            if (filter == "")
            {
                dg_RawData.ItemsSource = null;
                dg_RawData.ItemsSource = journeryData.jtis_journey_time;
            }
            else
            {
                dg_RawData.ItemsSource = null;
                dg_RawData.ItemsSource = journeryData.jtis_journey_time.FindAll(val => val.DESTINATION_ID == filter);
            }

            if (order == ListSortDirection.Ascending)
            {
                SortDataGrid(dg_RawData, sortColumnIndex, ListSortDirection.Ascending);
            }
            else
            {
                SortDataGrid(dg_RawData, sortColumnIndex, ListSortDirection.Descending);
            }
            
        }

        /// <summary>
        /// destination filter
        /// </summary>
        private string desFilter = "";
        private void cbDestinationFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbDestinationFilter.SelectedItem != null)
            {
                desFilter = cbDestinationFilter.SelectedItem.ToString();
                RefreshJouneryData();
            }
        }

        /// <summary>
        /// clear all fiter selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClearFilter_Click(object sender, RoutedEventArgs e)
        {
            desFilter = "";
            cbDestinationFilter.SelectedItem = null;
            RefreshJouneryData();
        }

        private ListSortDirection? order;
        private int sortColumnIndex = 3;
        /// <summary>
        /// get the next sort order and sort column for next data refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dg_RawData_Sorting(object sender, DataGridSortingEventArgs e)
        {
            sortColumnIndex = e.Column.DisplayIndex;
            if (e.Column.SortDirection != null)
            {
                order = e.Column.SortDirection; // the sort direction before sort event handel
                if (order == ListSortDirection.Descending)
                {
                    order = ListSortDirection.Ascending;
                }
                else
                {
                    order = ListSortDirection.Descending;
                }
            }
            else
            {
                order = ListSortDirection.Descending;
            }
        }
    }
}
