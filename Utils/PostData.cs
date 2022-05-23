using NetCore_01.Models;

namespace NetCore_01.Utils
{
    public static class PostData
    {

        private static List<Post> posts;

        public static List<Post> GetPosts()
        {
            if(PostData.posts != null)
            {
                return PostData.posts;
            }

            List<Post> nuovaListaPosts = new List<Post>();

            for(int i=0; i<1; i++)
            {
                Post post = new Post(i, "Titolo post: " + i, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.", "https://picsum.photos/id/" + i + "/300/200",20);
                nuovaListaPosts.Add(post);
            }

            Post post1 = new Post(1,"Esplora il mare","Fantastica giornata al mare in compagnia del nostro esperto marino!", "https://picsum.photos/id/" + 1 + "/300/200",150);
            nuovaListaPosts.Add(post1);

            Post post2 = new Post(2, "Esplora la terra", "Fantastica giornata nel deserto del sahara in compagnia di Mohamed Salah!", "https://picsum.photos/id/" + 2 + "/300/200",130);
            nuovaListaPosts.Add(post2);

            PostData.posts = nuovaListaPosts;

            return PostData.posts;

        }

    }
}
