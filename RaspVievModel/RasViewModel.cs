using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Student_Assistent.RaspVievModel
{
    class RasViewModel : DependencyObject
    {
        public string FilterRasp
        {
            get { return (string)GetValue(FilterRaspProperty); }
            set { SetValue(FilterRaspProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterRasp.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterRaspProperty =
             DependencyProperty.Register("FilterRasp", typeof(string), typeof(RasViewModel), new PropertyMetadata("", FilterRasp_Changed));

        private static void FilterRasp_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as RasViewModel;
            if (current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.FilterPasp;
            }
        }

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(RasViewModel), new PropertyMetadata(null));
        public RasViewModel()
        {
            Items = CollectionViewSource.GetDefaultView(DataRasp.DataRas.GetDataRas());
            Items.Filter = FilterPasp;
        }
        private bool FilterPasp(object obj)
        {
            bool result = true;
            DataRasp.DataRas dataRas = obj as DataRasp.DataRas;
            if(!string.IsNullOrWhiteSpace(FilterRasp) && !dataRas.Place.Contains(FilterRasp) && dataRas != null && !dataRas.Teacher.Contains(FilterRasp) && !dataRas.Time.Contains(FilterRasp) && !dataRas.Subject.Contains(FilterRasp) && !dataRas.Type.Contains(FilterRasp))
            {
                return false;
            }
            return result;
        }
    }
}
