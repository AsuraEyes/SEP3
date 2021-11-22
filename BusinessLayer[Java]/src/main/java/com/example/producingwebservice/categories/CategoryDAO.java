package com.example.producingwebservice.categories;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import io.spring.guides.gs_producing_web_service.Category;
import io.spring.guides.gs_producing_web_service.Event;
import io.spring.guides.gs_producing_web_service.Game;
import io.spring.guides.gs_producing_web_service.GameList;

import javax.annotation.Resource;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class CategoryDAO implements Categories
{
  private DatabaseHelper<Category> helper;

  @Resource(name="jdbcUrl")
  private String jdbcUrl;

  @Resource(name="username")
  private String username;

  @Resource(name="password")
  private String password;

  public CategoryDAO(){

  }

  private DatabaseHelper<Category> helper(){
    if(helper == null)
      helper = new DatabaseHelper<>(jdbcUrl, username, password);
    return helper;
  }

  private static Category createCategory(int id, String name){
    Category newCategory = new Category();
    newCategory.setId(id);
    newCategory.setName(name);
    return newCategory;
  }

  private static class CategoryMapper implements DataMapper<Category>
  {
    public Category create(ResultSet rs) throws SQLException
    {
      int id = rs.getInt("id");
      String name = rs.getString("name");
      return createCategory(id, name);
    }
    }
}
