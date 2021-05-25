using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationLayer
{
    public static class AppValidations
    {
        public const double POSITVE_NUM_MIN_VALUE_0 = 0;
        public const double POSITVE_NUM_MIN_VALUE_1 = 1;
        public const double NEGATIVE_NUM_MIN_VALUE = -NUM_MAX_VALUE;
        public const double NUM_MAX_VALUE = 999999999;
        public const double MAX_VACATION_PERIOD = 365;
        public const int SMALL_TEXT_MIN_LENGTH = 1;
        public const int NORMAL_TEXT_MIN_LENGTH = 3;
        public const int NORMAL_TEXT_MAX_LENGTH = 50;
        public const int LONG_TEXT_MIN_LENGTH = 3;
        public const int LONG_TEXT_MAX_LENGTH = 150;
        public const int PASSWORD_MIN_LENGTH = 8;
        public const int PASSWORD_MAX_LENGTH = 50;
        public const int MIN_SYSTEM_TIMEOUT_MIN = 10;
        public const int MAX_SYSTEM_TIMEOUT_MIN = 10080;
    }
}
