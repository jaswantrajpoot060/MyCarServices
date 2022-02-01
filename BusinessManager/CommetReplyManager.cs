using System;
using System.Collections.Generic;
using DataLayer;
using BusinessObject;

namespace BusinessManager
{
    [Obsolete]
    public class CommentReplyManager
    {
        public static void Add(CommentReply commentreply)
        {
            if (commentreply == null)
            {
                throw new ArgumentException("commentreply is null.");
            }

            CommentReplyDB.Add(commentreply);
        }

        public static void Update(CommentReply commentreply)
        {
            if (commentreply == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (commentreply.Id == null || commentreply.Id == default)
            {
                throw new ArgumentException("commentreply.Id value not set.");
            }

            CommentReplyDB.Update(commentreply);
        }

        public static void Delete(CommentReply commentreply)
        {
            if (commentreply == null)
            {
                throw new ArgumentException("commentreply is null.");
            }

            if (commentreply.Id == null || commentreply.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            CommentReplyDB.Delete(commentreply);
        }

        public static CommentReply GetById(Guid id)
        {
            CommentReply commentreply = CommentReplyDB.GetById(id);
            return commentreply;
        }
        public static List<CommentReply> GetByRefId(Guid RefId)
        {
            return CommentReplyDB.GetByRefId(RefId);
        }

        public static List<CommentReply> GetAll()
        {
            return CommentReplyDB.GetAll();
        }

        public static System.Data.DataSet Getdataset()
        {
            return CommentReplyDB.Getdataset();
        }

        public static List<CommentReply> Search(string word)
        {
            return CommentReplyDB.Search(word);
        }

    }
}