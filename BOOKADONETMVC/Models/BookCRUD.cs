﻿using System.Data.SqlClient;

namespace BOOKADONETMVC.Models
{
    public class BookCRUD
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public BookCRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }

        public IEnumerable<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();
            string qry = "select * from BookAdoNET where isActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Book b = new Book();
                    b.Id = Convert.ToInt32(dr["id"]);
                    b.Name = dr["name"].ToString();
                    b.Price = Convert.ToDouble(dr["price"]);
                    b.Authour = dr["author"].ToString();
                    list.Add(b);


                }
            }
            con.Close();
            return list;
        }
        public Book GetBookById(int id)
        {
            Book b = new Book();
            string qry = "select * from BookAdoNET where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    b.Id = Convert.ToInt32(dr["id"]);
                    b.Name = dr["name"].ToString();
                    b.Price = Convert.ToDouble(dr["price"]);
                    b.Authour = dr["author"].ToString();
                }
            }
            con.Close();
            return b;
        }
        public int AddBook(Book book)
        {
            book.isActive = 1;
            int result = 0;
            string qry = "insert into BookAdoNET values(@name,@price,@author,@isActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", book.Name);
            cmd.Parameters.AddWithValue("@price", book.Price);
            cmd.Parameters.AddWithValue("@author", book.Authour);
            cmd.Parameters.AddWithValue("@isActive", book.isActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }
        public int UpdateBook(Book book)
        {
            book.isActive = 1;
            int result = 0;
            string qry = "update BookAdoNET set name=@name,price=@price,author=@author,isActive=@isActive where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", book.Name);
            cmd.Parameters.AddWithValue("@price", book.Price);
            cmd.Parameters.AddWithValue("@author", book.Authour);
            cmd.Parameters.AddWithValue("@isActive", book.isActive);
            cmd.Parameters.AddWithValue("@id", book.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        // soft delete --> record should be present in DB , but should not visible on the form
        public int DeleteBook(int id)
        {
            int result = 0;
            string qry = "update BookAdoNET set isActive=0 where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }

}

