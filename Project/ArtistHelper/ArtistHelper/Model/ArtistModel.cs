using DevExpress.Mvvm.Native;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArtistHelper.Model
{
    // Generic 타입으로 교체하면서
    // 테스트의 수준도 한차원 높인다.
    // 테스트는 무조건 입력이 쉽고, 출력이 간단하도록 구성한다.
    // 일반 value Test, MinMax Test, Exception Test등 기능별로 구성한다.

    public class ArtistModel<T> where T : struct
    {
        #region 프로퍼티
        public Width<T> Width { get; set; } // 이미지 가로 사이즈
        public Height<T> Height { get; set; } // 이미지 세로 사이즈
        public Grid<T> LineGrid { get; set; } // 선 굵기
        public Width<T> MinWidth { get; set; } // 사각형 최소 가로 길이
        public Height<T> MinHeight { get; set; } // 사각형 최소 세로 길이
        public Point<T> EndPoint { get; set; } // 종점
        public int BoxCount { get; set; } // 사각형 개수
        public int FigureType { get; set; } // 도형 종류
        public string Name { get; set; }
        #endregion

        #region 생성자
        public ArtistModel() { }
        public ArtistModel(ArtistModel<T> artists)
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

    #region DDD Double Value
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

    public class Width<T> : ValueObject where T : struct
    {
        private double _minValue = 0;
        private double _maxValue = 2000;
        private double _value;
        private bool _exceptionSwitch = false;

        public Width() => _value = 0.0;

        public Width(T value)
        {
            ModifyValue(Convert.ToDouble(value));
        }
        public Width(double value)
        {
            ModifyValue(value);
        }
        public Width(T value, T minValue, T maxValue)
        {
            SetMinValue(Convert.ToDouble(minValue));
            SetMaxValue(Convert.ToDouble(maxValue));
            ModifyValue(Convert.ToDouble(value));
        }
        public Width(T value, double minValue, double maxValue)
        {
            SetMinValue(minValue);
            SetMaxValue(maxValue);
            ModifyValue(Convert.ToDouble(value));
        }
        public Width(double value, double minValue, double maxValue)
        {
            SetMinValue(minValue);
            SetMaxValue(maxValue);
            ModifyValue(value);
        }

        public void ModifyValue(double value)
        {
            //if(value == null) throw new ArgumentNullException(nameof(value));

            if (value < _minValue)
            {
                _value = _minValue;
                if (_exceptionSwitch)
                    throw new ArgumentException("입력 값이 " + _minValue.ToString() + "보다 작습니다. 임의로 값을 조정합니다.");
                return;
            }

            if ( value > _maxValue)
            {
                _value = _maxValue;
                if (_exceptionSwitch)
                    throw new ArgumentException("입력 값이 " + _minValue.ToString() + "보다 작습니다. 임의로 값을 조정합니다.");
                return;
            }

            _value = value;
        }
        public void SetMinValue(double value)
        {
            if (value > _maxValue) throw new ArgumentException("입력 값이 " + _maxValue.ToString() + "보다 큽니다.");

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
        public void SetMaxValue(double value)
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
        public void SetMinMaxValue(T minValue, T maxValue)
        {
            SetMinValue(Convert.ToDouble(minValue));
            SetMaxValue(Convert.ToDouble(maxValue));
        }
        public void SetMinMaxValue(double minValue, double maxValue)
        {
            SetMinValue(minValue);
            SetMaxValue(maxValue);
        }
        public double GetValue()
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

    public class Height<T> : Width<T> where T : struct
    {
        public Height() : base() { }
        public Height(T value) : base(value) { }
        public Height(T value, T minValue, T maxValue) : base(value, minValue, maxValue) { }
    }

    public class Grid<T> : Width<T> where T : struct
    {
        public Grid() : base(0.0, 0.0, 50.0) { }
        public Grid(T value) : base(value, 0, 50) { }
        public Grid(T value, T minValue, T maxValue) : base(value, minValue, maxValue) { }
    }

    public class Position<T> : Width<T> where T : struct
    {
        public Position() : base(0, -1000, 1000) { }
        public Position(T value) : base(value, -1000, 1000) { }
        public Position(T value, T minValue, T maxValue) : base(value, minValue, maxValue) { }
    }

    public class Point<T> where T : struct
    {
        public double x
        {
            get
            {
                return X.GetValue();
            }
        }
        public double y
        {
            get
            {
                return Y.GetValue();
            }
        }
        public Position<T> X { get; set; }
        public Position<T> Y { get; set; }

        public Point()
        {
            X = new Position<T>();
            Y = new Position<T>();
        }

        public Point(T x, T y) : this()
        {
            X.ModifyValue(Convert.ToDouble(x));
            Y.ModifyValue(Convert.ToDouble(y));
        }
        public Point(double x, double y) : this()
        {
            X.ModifyValue(x);
            Y.ModifyValue(y);
        }
    }

    public class Count<T> : Width<T> where T : struct
    {
        public Count() : base(0, 0, 100) { }
        public Count(T value) : base(value, 0 ,100) { }
        public Count(T value, T minValue, T maxValue) : base(value, minValue, maxValue) { }
    }

    #endregion
}
