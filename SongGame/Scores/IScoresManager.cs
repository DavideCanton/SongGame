﻿namespace SongGame.Scores
{
    public interface IScoresManager
    {
        int Ok { get; }
        int Wrongs { get; }

        void AddOk();
        void AddWrong();
    }
}