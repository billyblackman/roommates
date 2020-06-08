using Microsoft.Data.SqlClient;
using Roommates.Models;
using System;
using System.Collections.Generic;

namespace Roommates.Repositories
{
    public class RoommateRepository : BaseRepository
    {
        public RoommateRepository(string connectionString) : base(connectionString) { }

        //Get a list of all roommates in the database

        public List<Roommate> GetAll()
        { 
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Roommate roommate" +
                        "JOIN Room room ON room.Id = roommate.RoomId";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Roommate> roommates = new List<Roommate>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int firstNameColumnPosition = reader.GetOrdinal("FirstName");
                        string firstNameValue = reader.GetString(firstNameColumnPosition);

                        int lastNameColumnPosition = reader.GetOrdinal("LastName");
                        string lastNameValue = reader.GetString(lastNameColumnPosition);

                        int rentPortionColumnPosition = reader.GetOrdinal("RentPortion");
                        int rentPortionValue = reader.GetInt32(rentPortionColumnPosition);

                        int moveInDateColumnPosition = reader.GetOrdinal("MoveInDate");
                        DateTime moveInDateValue = reader.GetDateTime(moveInDateColumnPosition);

                        int roomIdColumnPosition = reader.GetOrdinal("RoomId");
                        int roomIdValue = reader.GetInt32(roomIdColumnPosition);

                        Roommate roommate = new Roommate
                        {
                            Id = idValue,
                            Firstname = firstNameValue,
                            Lastname = lastNameValue,
                            RentPortion = rentPortionValue,
                            MovedInDate = moveInDateValue,
                            Room = roomIdValued
                        }
                    }

                    reader.Close();

                    return roommates;
                }
            }
        }
    }
}
