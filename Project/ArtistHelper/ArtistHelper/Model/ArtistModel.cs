using DevExpress.Mvvm.Native;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Windows;

namespace ArtistHelper.Model
{
    public class ArtistModel
    {
        #region 프로퍼티
        public Width Width { get; set; } // 이미지 가로 사이즈
        public Height Height { get; set; } // 이미지 세로 사이즈
        public Grid LineGrid { get; set; } // 선 굵기
        public Width MinWidth { get; set; } // 사각형 최소 가로 길이
        public Height MinHeight { get; set; } // 사각형 최소 세로 길이
        public Point EndPoint { get; set; } // 종점
        public int BoxCount { get; set; } // 사각형 개수
        public int FigureType { get; set; } // 도형 종류
        public string Name { get; set; }
        #endregion

        #region 생성자
        public ArtistModel() { }
        public ArtistModel(ArtistModel artists)
        {
            Width = artists.Width;
            Height = artists.Height;
            LineGrid = artists.LineGrid;
            MinWidth = artists.MinWidth;
            MinHeight = artists.MinHeight;
            EndPoint = artists.EndPoint;
            BoxCount = artists.BoxCount;
            FigureType = artists.FigureType;
        }
        #endregion
    }

    #region DDD Value
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, right) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
        public static bool operator ==(ValueObject one, ValueObject two)
        {
            return EqualOperator(one, two);
        }

        public static bool operator !=(ValueObject one, ValueObject two)
        {
            return NotEqualOperator(one, two);
        }
    }

    public class Width : ValueObject
    {
        private int _minValue = 0;
        private int _maxValue = 2000;
        private int _value;
        private bool _exceptionSwitch = false;

        public Width() => _value = 0;

        public Width(int value)
        {
            ModifyValue(value);
        }
        public Width(int value, int minValue, int maxValue)
        {
            SetMinValue(minValue);
            SetMaxValue(maxValue);
            ModifyValue(value);
        }

        public void  ModifyValue(int value)
        {
            //if(value == null) throw new ArgumentNullException(nameof(value));

            if (value < _minValue)
            {
                _value = _minValue;
                if(_exceptionSwitch)
                    throw new ArgumentException("입력 값이 " + _minValue.ToString() + "보다 작습니다. 임의로 값을 조정합니다.");
                return;
            }

            if (value > _maxValue)
            {
                _value = _maxValue;
                if (_exceptionSwitch)
                    throw new ArgumentException("입력 값이 " + _minValue.ToString() + "보다 작습니다. 임의로 값을 조정합니다.");
                return;
            }

            _value = value;
        }
        public void SetMinValue(int value)
        {
            if(value > _maxValue) throw new ArgumentException("입력 값이 " + _maxValue.ToString() + "보다 큽니다.");
            
            if (_value < value)
            {
                _value = value;
                _minValue = value;
                if (_exceptionSwitch)
                    throw new ArgumentException("입력 값이 " + _value.ToString() + "보다 작습니다. 임의로 Value값을 조정합니다.");
                return;
            }
            _minValue = value;
        }
        public void SetMaxValue(int value)
        {
            if (value < _minValue) throw new ArgumentException("입력 값이 " + _minValue.ToString() + "보다 작습니다.");

            if (_value > value)
            {
                _value = value;
                _maxValue = value;
                if (_exceptionSwitch)
                    throw new ArgumentException("입력 값이 " + _value.ToString() + "보다 큽니다. 임의로 Value값을 조정합니다.");
                return;
            }
            _maxValue = value;
        }
        public void SetMinMaxValue(int minValue, int maxValue)
        {
            SetMinValue(minValue);
            SetMaxValue(maxValue);
        }
        public int GetValue()
        {
            return _value;
        }

        public void SetException(bool eSwitch)
        {
            _exceptionSwitch = eSwitch;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }
    }

    public class Height : Width 
    {
        public Height() : base() { }
        public Height(int value) : base(value) { }
        public Height(int value, int minValue, int maxValue) : base(value, minValue, maxValue) { }
    }

    public class Grid : Width
    {
        public Grid() : this(0, 0, 50) { }
        public Grid(int value) : base(value, 0, 50) { }
        public Grid(int value, int minValue, int maxValue) : base(value, minValue, maxValue) { }
    }

    public class Position : Width
    {
        public Position() : base(0, -1000, 1000) { }
        public Position(int value) : base(value, -1000, 1000) { }
        public Position(int value, int minValue, int maxValue) : base(value, minValue, maxValue) { }
    }

    public class Point
    {
        public int x
        {
            get
            {
                return X.GetValue();
            }
        }
        public int y
        {
            get
            {
                return Y.GetValue();
            }
        }
        public Position X { get; set; }
        public Position Y { get; set; }

        public Point()
        {
            X = new Position();
            Y = new Position();
        }

        public Point(int x, int y) : this()
        {
            X.ModifyValue(x);
            Y.ModifyValue(y);
        }
    }
    #endregion

    // Point Test
    // int 뿐만 아니라 float에도 동작하도록 : 제너릭 클래스 : https://developer-talk.tistory.com/206
}
