using System;
using System.Collections.Generic;
using DataLayer;
using BusinessObject;

namespace BusinessManager
{
    [Obsolete]
    public class CommentManager
    {
        public static void Add(Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentException("comment is null.");
            }

            CommentDB.Add(comment);
        }

        public static void Update(Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (comment.Id == null || comment.Id == default)
            {
                throw new ArgumentException("comment.Id value not set.");
            }

            CommentDB.Update(comment);
        }

        public static void Delete(Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentException("comment is null.");
            }

            if (comment.Id == null || comment.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            CommentDB.Delete(comment);
        }

        public static Comment GetById(Guid id)
        {
            Comment comment = CommentDB.GetById(id);
            return comment;
        }

        public static List<Comment> GetAll()
        {
            return CommentDB.GetAll();
        }

        public static System.Data.DataSet Getdataset()
        {
            return CommentDB.Getdataset();
        }

        public static List<Comment> Search(string word)
        {
            return CommentDB.Search(word);
        }

        public static List<Comment> GetByRefId(Guid RefId)
        {
            return CommentDB.GetByRefId(RefId);
        }

    }
}