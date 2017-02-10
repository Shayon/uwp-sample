using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Data.Text;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSampleApp.Importers
{

    public static class Importers
    {
        public static List<Website> Import(DbContext context, List<Website> apiWebsites)
        {
            return Importer<Website, Website>.Import(context, apiWebsites, -1, (dbWebsite, apiWebsite) =>
            {
                dbWebsite.Url = apiWebsite.Url;
                dbWebsite.Foo1 = apiWebsite.Foo1;
                dbWebsite.Foo2 = apiWebsite.Foo2;
                dbWebsite.Foo3 = apiWebsite.Foo3;
                dbWebsite.Foo4 = apiWebsite.Foo4;
                dbWebsite.Foo5 = apiWebsite.Foo5;
                dbWebsite.Foo6 = apiWebsite.Foo6;
                dbWebsite.Foo7 = apiWebsite.Foo7;
                dbWebsite.Foo8 = apiWebsite.Foo8;
                dbWebsite.Foo9 = apiWebsite.Foo9;
                dbWebsite.Foo10 = apiWebsite.Foo10;
                dbWebsite.Blogs = Import(context, apiWebsite.Blogs, dbWebsite.WebsiteId.Value);
            });
        }

        public static List<Blog> Import(DbContext context, List<Blog> apiBlogs, int WebsiteId)
        {
            return Importer<Blog, Blog>.Import(context, apiBlogs, WebsiteId, (dbBlog, apiBlog) =>
            {
                dbBlog.DomainUrl = apiBlog.DomainUrl;
                dbBlog.WebsiteId = WebsiteId;
                dbBlog.Foo1 = apiBlog.Foo1;
                dbBlog.Foo2 = apiBlog.Foo2;
                dbBlog.Foo3 = apiBlog.Foo3;
                dbBlog.Foo4 = apiBlog.Foo4;
                dbBlog.Foo5 = apiBlog.Foo5;
                dbBlog.Foo6 = apiBlog.Foo6;
                dbBlog.Foo7 = apiBlog.Foo7;
                dbBlog.Foo8 = apiBlog.Foo8;
                dbBlog.Foo9 = apiBlog.Foo9;
                dbBlog.Foo10 = apiBlog.Foo10;
                dbBlog.Topics = Import(context, apiBlog.Topics, dbBlog.BlogId.Value);
            });
        }

        public static List<Topic> Import(DbContext context, List<Topic> apiTopics, int BlogId)
        {
            return Importer<Topic, Topic>.Import(context, apiTopics, BlogId, (dbTopic, apiTopic) =>
            {
                dbTopic.TopicName = apiTopic.TopicName;
                dbTopic.Url = apiTopic.Url;
                dbTopic.BlogId = BlogId;
                dbTopic.Foo1 = apiTopic.Foo1;
                dbTopic.Foo2 = apiTopic.Foo2;
                dbTopic.Foo3 = apiTopic.Foo3;
                dbTopic.Foo4 = apiTopic.Foo4;
                dbTopic.Foo5 = apiTopic.Foo5;
                dbTopic.Foo6 = apiTopic.Foo6;
                dbTopic.Foo7 = apiTopic.Foo7;
                dbTopic.Foo8 = apiTopic.Foo8;
                dbTopic.Foo9 = apiTopic.Foo9;
                dbTopic.Foo10 = apiTopic.Foo10;
                dbTopic.Posts = Import(context, apiTopic.Posts, dbTopic.TopicId.Value);
            });
        }

        public static List<Post> Import(DbContext context, List<Post> apiPosts, int TopicId)
        {
            return Importer<Post, Post>.Import(context, apiPosts, TopicId, (dbPost, apiPost) =>
            {
                dbPost.Content = apiPost.Content;
                dbPost.Foo1 = apiPost.Foo1;
                dbPost.Foo2 = apiPost.Foo2;
                dbPost.Foo3 = apiPost.Foo3;
                dbPost.Foo4 = apiPost.Foo4;
                dbPost.Foo5 = apiPost.Foo5;
                dbPost.Foo6 = apiPost.Foo6;
                dbPost.Foo7 = apiPost.Foo7;
                dbPost.Foo8 = apiPost.Foo8;
                dbPost.Foo9 = apiPost.Foo9;
                dbPost.Foo10 = apiPost.Foo10;
                dbPost.Title = apiPost.Title;
                dbPost.TopicId = TopicId;
            });
        }
    }


    public static class Importer<TDb, TApi>
    where TDb : BaseModel
    where TApi : IHasServerId
    {
        public static List<TDb> Import(
            DbContext context,
            List<TApi> webEntities,
            int scopeId,
            Action<TDb, TApi> copyFields)
        {
            var createdAndUpdatedDbEntities = new List<TDb>();

            if (webEntities == null || !webEntities.Any()) { return createdAndUpdatedDbEntities; }

            var dbEntitiesToDelete =
                new HashSet<TDb>(
                    context.Set<TDb>().Where(entity => entity.GetScopeId() == scopeId));

            foreach (var webEntity in webEntities)
            {
                var dbEntity = Import(context, webEntity, copyFields);
                createdAndUpdatedDbEntities.Add(dbEntity);
                dbEntitiesToDelete.Remove(dbEntity);
            }

            foreach (var priorDbEntity in dbEntitiesToDelete)
            {
                context.Entry(priorDbEntity).State = EntityState.Deleted;
            }

            return createdAndUpdatedDbEntities;
        }

        public static TDb Import(
            DbContext context,
            TApi webEntity,
            Action<TDb, TApi> copyFields)
        {
            if (webEntity == null) { return null; }

            TDb dbEntity = null;

            var dbEntitySet = context.Set<TDb>();

            foreach (var entity in dbEntitySet)
            {
                if (entity.ServerId == webEntity.ServerId) { dbEntity = entity; break; }
            }

            //var dbEntity =
            //    context
            //        .ChangeTracker
            //        .Entries<TDb>()
            //        .Select(entry => entry.Entity)
            //        .FirstOrDefault(
            //            entity => entity.ServerId == webEntity.ServerId) ??
            //    context
            //        .Set<TDb>()
            //        .FirstOrDefault(
            //            entity => entity.ServerId == webEntity.ServerId);

            if (dbEntity == null)
            {
                dbEntity = Activator.CreateInstance<TDb>();
                dbEntity.ServerId = webEntity.ServerId;
                context.Entry(dbEntity).State = EntityState.Added;
            }

            copyFields(dbEntity, webEntity);
            context.ChangeTracker.DetectChanges();
            return dbEntity;
        }
    }
}
