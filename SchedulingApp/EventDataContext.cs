using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace SchedulingApp
{
    public class Event
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }


        public virtual ICollection<Time> Times { get; set; }
        public virtual ICollection<Attendee> Attendees { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Event()
        {
            Id = Guid.NewGuid();
        }
    }

    public class Time
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime Value { get; set; }
        public virtual bool Selected { get; set; }


        public virtual Event ForEvent { get; set; }
        public virtual ICollection<TimeVote> Votes { get; set; }

        public Time()
        {
            Id = Guid.NewGuid();
        }
    }

    public class TimeVote
    {
        public virtual Guid Id { get; set; }

        public virtual Time VotedOn { get; set; }
        public virtual Attendee Voter { get; set; }

        public TimeVote()
        {
            Id = Guid.NewGuid();
        }
    }

    public class Location
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual bool Selected { get; set; }

        public virtual Event ForEvent { get; set; }

        public virtual ICollection<LocationVote> Votes { get; set; }

        public Location()
        {
            Id = Guid.NewGuid();
        }
    }

    public class LocationVote
    {
        public virtual Guid Id { get; set; }

        public virtual Location VotedOn { get; set; }
        public virtual Attendee Voter { get; set; }

        public LocationVote()
        {
            Id = Guid.NewGuid();
        }
    }

    public class Attendee
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string AccessCode { get; set; }

        public virtual Event ForEvent { get; set; }
        public Attendee()
        {
            Id = Guid.NewGuid();
            AccessCode = RandomString(20);
        }

        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }

    public class Comment
    {
        public virtual Guid Id { get; set; }
        public virtual string Value { get; set; }

        public virtual Event ForEvent { get; set; }
        public virtual Attendee CommentBy { get; set; }

        public Comment()
        {
            Id = Guid.NewGuid();
        }
    }

    public class EventDataContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
    }
}