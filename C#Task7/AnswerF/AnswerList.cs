using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Task7.AnswerF
{
    internal class AnswerList
	{
        private Answer[] _answers;
        private int _count;
        public int Count {  get { return _count; } }
        public AnswerList(int capacity=10)
        {
            _answers = new Answer[capacity];
            _count = 0;
        }
        public Answer  this[int index]
		{
			get { return _answers[index]; }
			set { _answers[index] = value; }
		}

        public void Add(Answer answer)
        {
            if (_count == _answers.Length)
                Array.Resize(ref _answers, _answers.Length * 2);

            _answers[_count++] = answer;
        }

        public Answer GetById(int id)
        {
            for (int i = 0; i < _count; i++)
                if (_answers[i].id == id)
                    return _answers[i];

            return null;
        }
    }
}
