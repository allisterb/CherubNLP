﻿using CherubNLP.Tokenize;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CherubNLP.UnitTest.Tokenize
{
    [TestClass]
    public class TreebankTokenizerTest
    {
        [TestMethod]
        public void ReplaceStartingQuoting()
        {
            var tokenizer = new TokenizerFactory(new TokenizationOptions
            {
            }, SupportedLanguage.English);
            tokenizer.GetTokenizer<TreebankTokenizer>();

            var tokens = tokenizer.Tokenize("«Hello!");

            Assert.IsTrue(tokens[0].Text == "«");
            Assert.IsTrue(tokens[0].Start == 0);

            Assert.IsTrue(tokens[1].Text == "Hello");
            Assert.IsTrue(tokens[1].Start == 1);

            Assert.IsTrue(tokens[2].Text == "!");
            Assert.IsTrue(tokens[2].Start == 6);
        }

        [TestMethod]
        public void ReplaceEndingQuoting()
        {
            var tokenizer = new TokenizerFactory(new TokenizationOptions
            {
            }, SupportedLanguage.English);
            tokenizer.GetTokenizer<TreebankTokenizer>();

            var tokens = tokenizer.Tokenize("Aren't you");

            Assert.IsTrue(tokens[0].Text == "Are");
            Assert.IsTrue(tokens[0].Start == 0);

            Assert.IsTrue(tokens[1].Text == "n't");
            Assert.IsTrue(tokens[1].Start == 3);

            Assert.IsTrue(tokens[2].Text == "you");
            Assert.IsTrue(tokens[2].Start == 7);
        }

        [TestMethod]
        public void ReplacePunctuation()
        {
            var tokenizer = new TokenizerFactory(new TokenizationOptions
            {
            }, SupportedLanguage.English);
            tokenizer.GetTokenizer<TreebankTokenizer>();

            var tokens = tokenizer.Tokenize("Hello World...");

            Assert.IsTrue(tokens[0].Text == "Hello");
            Assert.IsTrue(tokens[0].Start == 0);

            Assert.IsTrue(tokens[1].Text == "World");
            Assert.IsTrue(tokens[1].Start == 6);

            Assert.IsTrue(tokens[2].Text == "...");
            Assert.IsTrue(tokens[2].Start == 11);
        }

        [TestMethod]
        public void ReplaceBrackets()
        {
            var tokenizer = new TokenizerFactory(new TokenizationOptions
            {
            }, SupportedLanguage.English);
            tokenizer.GetTokenizer<TreebankTokenizer>();

            var tokens = tokenizer.Tokenize("<Hello.>");

            Assert.IsTrue(tokens[0].Text == "<");
            Assert.IsTrue(tokens[0].Start == 0);

            Assert.IsTrue(tokens[1].Text == "Hello");
            Assert.IsTrue(tokens[1].Start == 1);

            Assert.IsTrue(tokens[2].Text == ".");
            Assert.IsTrue(tokens[2].Start == 6);

            Assert.IsTrue(tokens[3].Text == ">");
            Assert.IsTrue(tokens[3].Start == 7);
        }

        [TestMethod]
        public void ReplaceConventions()
        {
            var tokenizer = new TokenizerFactory(new TokenizationOptions
            {
            }, SupportedLanguage.English);
            tokenizer.GetTokenizer<TreebankTokenizer>();

            var tokens = tokenizer.Tokenize("I cannot jump.");

            Assert.IsTrue(tokens[0].Text == "I");
            Assert.IsTrue(tokens[0].Start == 0);

            Assert.IsTrue(tokens[1].Text == "can");
            Assert.IsTrue(tokens[1].Start == 2);

            Assert.IsTrue(tokens[2].Text == "not");
            Assert.IsTrue(tokens[2].Start == 5);

            Assert.IsTrue(tokens[3].Text == "jump");
            Assert.IsTrue(tokens[3].Start == 9);

            Assert.IsTrue(tokens[4].Text == ".");
            Assert.IsTrue(tokens[4].Start == 13);
        }

        [TestMethod]
        public void ReplaceConventionsIncludeMultipleSymbol()
        {
            var tokenizer = new TokenizerFactory(new TokenizationOptions
            {
            }, SupportedLanguage.English);
            tokenizer.GetTokenizer<TreebankTokenizer>();

            var tokens = tokenizer.Tokenize("I jump. And you?");

            Assert.IsTrue(tokens[0].Text == "I");
            Assert.IsTrue(tokens[0].Start == 0);

            Assert.IsTrue(tokens[1].Text == "jump");
            Assert.IsTrue(tokens[1].Start == 2);

            Assert.IsTrue(tokens[2].Text == ".");
            Assert.IsTrue(tokens[2].Start == 6);

            Assert.IsTrue(tokens[3].Text == "And");
            Assert.IsTrue(tokens[3].Start == 8);

            Assert.IsTrue(tokens[4].Text == "you");
            Assert.IsTrue(tokens[4].Start == 12);

            Assert.IsTrue(tokens[5].Text == "?");
            Assert.IsTrue(tokens[5].Start == 15);
        }
    }
}
