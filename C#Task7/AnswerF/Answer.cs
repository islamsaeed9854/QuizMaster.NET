using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Task7.AnswerF
{
    internal class Answer : IComparable<Answer>, ICloneable, IEquatable<Answer>
    {




        public int id { get; set; }
        public string Text { get; set; }

        public Answer(int _id, string _text)
        {
            id = _id;
            Text = _text;
        }
        public override string ToString()
        {
            return $"{id}:{Text}";
        }
        public override bool Equals(object? obj)
        { if (obj is Answer) {
                if (GetType() == obj.GetType())
                {
                    Answer answer = (Answer)obj;
                    return answer.id == id;
                }
            }
            return false;
        }

        int IComparable<Answer>.CompareTo(Answer? other)
        {
            if (other is Answer)
            {
                if (GetType() == other.GetType())
                {
                    Answer answer = (Answer)other;
                    return id.CompareTo(answer.id);
                }
            }
            return 1;
        }
        public override int GetHashCode() {

            return HashCode.Combine(id);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public bool Equals(Answer? other)
        {
            if (other != null && other is Answer)
            {
                return this.id == other.id;
            }
            return false;
        }
        
        public static bool operator ==(Answer a, Answer b){
            if (ReferenceEquals(a, b))
                return true;

            if (a is null || b is null)
                return false;

            return a.id == b.id;
        }
        public static bool operator !=(Answer a, Answer b)
        {
            return !(a == b);
        }
    }
}
