namespace Lab4.TableElements
{
    public class GroupTableElement
    {
        public double Pit { get; set; } // теоретическая вероятность попадания в интервал
        public double Npi { get; set; } // теоретическое число значений, попавших в интервал

        public double I { get; set; }
        public double DeltaI { get; set; } // the length of the interval
        public double Mi { get; set; } // number of variants in the interval
        public double Ai { get; set; } // left border of the interval   (Ai = x1 + (i - 1)/ deltaI;)
        public double Bi { get; set; } // right border of the interval (Bi = A(i + 1) ;)
        public double Pi { get; set; } // Mi/n
        public double Fi { get; set; } // the heigth of the rectangle: fi = pi/deltaI = Mi/(n*deltaI)
        public double Y { get; set; } // <Y>
    }
}
