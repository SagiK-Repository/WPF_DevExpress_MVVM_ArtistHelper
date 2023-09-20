﻿using ArtistHelper.Common;
using ArtistHelper.Model;
using DevExpress.Mvvm;
using System;
using System.ComponentModel;

namespace ArtistHelper.ViewModel
{
    public class PanelViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region 프로퍼티
        public ArtistModel<double> ArtistModels
        {
            get { return GetProperty(() => ArtistModels); }
            set 
            {
                SetProperty(() => ArtistModels, value);
                _update();
            }
        }
        public double Width
        {
            get => ArtistModels.Width.GetValue();
            set
            {
                ArtistModels.Width.ModifyValue(value);
                _update();
            }
        }
        public double Height
        {
            get => ArtistModels.Height.GetValue();
            set
            {
                ArtistModels.Height.ModifyValue(value);
                _update();
            }
        }
        public double LineGrid
        {
            get => ArtistModels.LineGrid.GetValue();
            set
            {
                ArtistModels.LineGrid.ModifyValue(value);
                _update();
            }
        }
        public double MinWidth
        {
            get => ArtistModels.MinWidth.GetValue();
            set
            {
                ArtistModels.MinWidth.ModifyValue(value);
                _update();
            }
        }
        public double MinHeight
        {
            get => ArtistModels.MinHeight.GetValue();
            set
            {
                ArtistModels.MinHeight.ModifyValue(value);
                _update();
            }
        }
        public double EndPointX
        {
            get => ArtistModels.EndPoint.X.GetValue();
            set
            {
                ArtistModels.EndPoint.X.ModifyValue(value);
                _update();
            }
        }
        public double EndPointY
        {
            get => ArtistModels.EndPoint.Y.GetValue();
            set
            {
                ArtistModels.EndPoint.Y.ModifyValue(value);
                _update();
            }
        }
        public int BoxCount
        {
            get => Convert.ToInt32(ArtistModels.BoxCount.GetValue());
            set
            {
                ArtistModels.BoxCount.ModifyValue(Convert.ToDouble(value));
                _update();
            }
        }
        #endregion

        #region 생성자
        public PanelViewModel()
        {
            _initialize();
        }
        void _initialize()
        {
            ArtistModels = ArtistHelperDataBase.GetDefaultArtistModel();
        }
        #endregion

        #region 메소드
        void _update()
        {
            OnPropertyChanged(nameof(Width));
            OnPropertyChanged(nameof(Height));
            OnPropertyChanged(nameof(LineGrid));
            OnPropertyChanged(nameof(MinWidth));
            OnPropertyChanged(nameof(MinHeight));
            OnPropertyChanged(nameof(EndPointX));
            OnPropertyChanged(nameof(EndPointY));
            OnPropertyChanged(nameof(BoxCount));
            ArtistHelperDataBase.GetPenel().Update(ArtistModels);
        }
        #endregion

        #region PropertyChanged Medhod
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
