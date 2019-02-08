using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Program {
  /*
   * Repository Design Pattern
   */

  // Generic Interface
  public interface IRepository<TEntity> where TEntity : class {
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entites);

    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entites);

    TEntity Get(int id);
    IEnumerable<TEntity> GetAll();
    //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
  }

  // Generic Repository class
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
    protected readonly DbContext Context;

    public Repository(DbContext context) {
      Context = context;
    }

    public void Add(TEntity entity) {
      Context.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entites) {
      Context.Set<TEntity>().AddRange(entites);
    }

    public void Remove(TEntity entity) {
      Context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entites) {
      Context.Set<TEntity>().RemoveRange(entites);
    }

    public TEntity Get(int id) {
      return Context.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll() {
      return Context.Set<TEntity>().ToList();
    }
  }

  public interface IRoomRepository : IRepository<Room> {
    //Room GetRoomWithMostDevices();
    IEnumerable<Room> GetRoomWithDevicesByRange(int pageIndex, int pageSize);
  }

  public class RoomRepository : Repository<Room>, IRoomRepository {
    public RoomRepository(DbContext context):base(context) {}
    public IEnumerable<Room> GetRoomWithDevicesByRange(int pageIndex, int pageSize) {
      return Context.Set<Room>().ToList();
    }
    //public Room GetRoomWithMostDevices(IEnumerable<Room> rooms) {
      //return Context.Set<Room>().Where((room, index) => room.components);
    //}
  }

  public interface IEntity {
    string name { get; }
    string description { get; }
  }

  public class Entity : IEntity {
    private string _name;
    public string name {
      get { return _name; }
      private set { _name = value; }
    }

    private string _description;
    public string description {
      get { return _description; }
      private set { _description = value; }
    }

    public Entity(string name, string description) {
      _name = name;
      _description = description;
    }
  }

  public class Device : Entity {
    public Device(string name, string description):base(name, description) {}
  }

  public class Component : Entity {
    private float _price;
    public float price {
      private set { _price = value; }
      get { return _price; }
    }

    public Component(string name, string description):base(name, description) {}
  }

  public class Room : Entity {
    public List<Component> components = new List<Component>();

    public Room(string name, string description):base(name, description) {}
  }

  class Program {
    public static int Main(string[] args) {
      Room room = new Room("C107", "PC ROOM");
      SqlConnection cnn = new SqlConnection();
      DbContext context = new DbContext(cnn, true);
      RoomRepository roomRepository = new RoomRepository(context);
      Console.WriteLine(roomRepository.Get(1));
      return 0;
    }
  }
}
