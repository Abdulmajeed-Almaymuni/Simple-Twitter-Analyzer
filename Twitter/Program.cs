using System;
using System.Collections;

namespace Twitter
{
    class Program
    {

        static void Twitter(string source)
        {
            ArrayList hashtags = new ArrayList();
            ArrayList mentions = new ArrayList();
            int pointer = 0;
            string holder = "";
            for (pointer = 0; pointer < source.Length; pointer++)
            {
                if (source[pointer].ToString().Contains("#"))
                {
                    holder += source[pointer++];                 
                    while (pointer < source.Length)
                    {
                        if (Char.IsLetterOrDigit(source[pointer]) && !Char.IsPunctuation(source[pointer]) || source[pointer].ToString().Contains("_"))
                        {
                            holder += source[pointer];
                        } else if(source[pointer].ToString().Contains(" "))
                        {
                            if (holder.Length == 1)
                            {
                                holder = "";
                            } else
                            {
                                hashtags.Add(holder);
                                holder = "";
                                break;
                            }

                        } else
                        {
                            holder = "";
                            break;
                        }
                        pointer++;
                    }
                }
                if ( pointer< source.Length && source[pointer].ToString().Contains("@"))
                {
                    holder += source[pointer++];
                    while (pointer < source.Length)
                    {
                        if (Char.IsLetterOrDigit(source[pointer]) || source[pointer].ToString().Contains("_"))
                        {
                            holder += source[pointer];
                        } else if (source[pointer].ToString().Contains(" "))
                        {
                            if(holder.Length == 1)
                            {
                                holder = "";
                            } else
                            {
                                mentions.Add(holder);
                                holder = "";
                                break;
                            }

                        } else
                        {
                            holder = "";
                            break;
                        }
                        pointer++;
                    }
                }
            }
            if(holder.Length > 0 && holder.Length!=1)
            {
                if (holder[0].ToString().Contains("@"))
                {
                    mentions.Add(holder);
                } else
                {
                    hashtags.Add(holder);
                }
            }
            Console.WriteLine("Number of hashtags: " + hashtags.Count);
            foreach (var hashtag in hashtags)
            {
                Console.WriteLine(hashtag);
            }

            Console.WriteLine("Number of mentions: " + mentions.Count);
            foreach (var mention in mentions)
            {
                Console.WriteLine(mention);
            }
        }
        static void Main(string[] args)
        {
            Twitter("@hethSET23e4_ @rooz_lbhdthdy6k1#No #not_like_this #g #TuwaiqBootCamp");
        }
    }
}
