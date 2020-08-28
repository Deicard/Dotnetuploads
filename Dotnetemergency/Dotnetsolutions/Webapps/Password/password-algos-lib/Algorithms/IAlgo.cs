using System;

namespace password_algos_lib.Algorithms {
    public interface IAlgo{
        string generate(String password);
    }
}