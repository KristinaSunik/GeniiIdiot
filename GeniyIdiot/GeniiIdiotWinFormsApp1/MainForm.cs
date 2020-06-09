﻿
using GeniyIdiotCommon;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GeniiIdiotWinFormsApp1
{
    public partial class GeniiIdiotWinFormsApp : Form
    {
        private User user;
        private Game game;

        public GeniiIdiotWinFormsApp()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var userSurnameForm = new UserSurnameForm();
            userSurnameForm.ShowDialog(this);
            var userNameForm = new UserNameForm();
            userNameForm.ShowDialog(this);
            user = new User(userNameForm.userNameTextBox.Text, userSurnameForm.UserSurnameTextBox.Text);
            game = new Game(user);
            PrintNextQuestion();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            int userAnswer;
            if (!int.TryParse(userAnswerTextBox.Text, out userAnswer))
            {
                MessageBox.Show("Введите число!");
            }

            game.AcceptUserAnswer(userAnswer);
            PrintNextQuestion();
        }



        private void PrintNextQuestion()
        {
            if (game.IsEnd())
            {
                user.Diagnose = Diagnose.Calculate(user);
                game.SaveResult();
                MessageBox.Show(user.Diagnose);
            }
            else
            {
                questionTextLabel.Text = game.PopRandomeQuestion().Text;
            }
        }
    }
}
