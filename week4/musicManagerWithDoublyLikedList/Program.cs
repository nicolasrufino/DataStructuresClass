Playlist play = new Playlist();

play.AddSong("Twinkly", "llcoolj", 4.67d);
play.AddSong("Small world", "someone who should die, painlessly", 3.78d);

play.RemoveSong("small world");

Console.WriteLine(play);

public class Playlist
{
    public SongNode head;
    public SongNode tail;
    public SongNode current;
    private Random random = new Random();

    public Playlist()
    {
        head = null;
        tail = null;
        current = null;
    }

    public void AddSong(string title, string artist, double duration)
    {
        SongNode newSong = new SongNode(title, artist, duration);

        if (head == null)
        {
            head = newSong;
            tail = newSong;
            current = newSong;
        }
        else
        {
            tail.Next = newSong;
            newSong.Previous = tail;
            tail = newSong;
            current = newSong;
        }

        Console.WriteLine($"Added song:{title}");
    }

    public void RemoveSong(string title)
    {
        SongNode temp = head;

        while (temp != null)
        {
            if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (temp.Previous != null)
                {
                    temp.Previous.Next = temp.Next;
                }
                else
                {
                    head = temp.Next;
                }

                if (temp.Next != null)
                {
                    temp.Next.Previous = temp.Previous;
                }
                else
                {
                    tail = temp.Previous;
                }
                current = null;
                Console.WriteLine($"Removed Song: {title}");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine($"Song not found:{title}");
    }
    public void playNext()
    {
        if (current.Next != null && current != null)
        {
            current = current.Next;
            //displayCurrentSong();

        }
        else
        {
            Console.WriteLine("This action can't be performed. There is no next song in the queue. ");
        }
    }
    public void playPrevious()
    {
        if (current != null && current.Previous != null)
        {
            current = current.Previous;

            //DisplayCurrentSong();
        }
        else if (current != null)
        {
            //I'm not so sure if my implementation here is appropriate. My goal is that when a user tries to play a previous song without there being one, he will play the current song from the beginning.
            Console.WriteLine("No previous songs detected. Replaying the current song");
            current = current;//this doesnt seem to be the best approach but I don't know what else could be introduced
            //DisplayCurrentSong();

        }

        else
        {
            Console.WriteLine("There are no previous songs.");
        }

    }
    public void DisplayCurrentSong()
    {
        if (current != null)
        {
            Console.WriteLine($"Now playing, {current.Title} \nby{current.Artist}\nDuration:{current.Duration}");
        }
        else
        {
            Console.WriteLine("No song is currently playing.");
        }
    }
}



public class SongNode
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public double Duration { get; set; }
    public SongNode Next { get; set; }
    public SongNode Previous { get; set; }

    List<SongNode> list = new List<SongNode>();
    public SongNode(string title, string artist, double duration)
    {
        Id = Guid.NewGuid();
        Title = title;
        Artist = artist;
        Duration = duration;
    }
}

