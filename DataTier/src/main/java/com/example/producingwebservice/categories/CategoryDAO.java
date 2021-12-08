package com.example.producingwebservice.categories;

import com.example.producingwebservice.db.DataMapper;
import com.example.producingwebservice.db.DatabaseHelper;
import io.spring.guides.gs_producing_web_service.Category;
import io.spring.guides.gs_producing_web_service.CategoryList;

import javax.annotation.Resource;
import java.sql.ResultSet;
import java.sql.SQLException;

public class CategoryDAO implements Categories {
    private DatabaseHelper<Category> helper;
    private final CategoryList categoryList;

    @Resource(name = "jdbcUrl")
    private String jdbcUrl;

    @Resource(name = "username")
    private String username;

    @Resource(name = "password")
    private String password;

    public CategoryDAO() {
        categoryList = new CategoryList();
    }

    private static Category createCategory(int id, String name) {
        Category newCategory = new Category();
        newCategory.setId(id);
        newCategory.setName(name);
        return newCategory;
    }

    private DatabaseHelper<Category> helper() {
        if (helper == null)
            helper = new DatabaseHelper<>(jdbcUrl, username, password);
        return helper;
    }

    @Override
    public CategoryList getCategories() {
        categoryList.getCategoryList().clear();
        categoryList.getCategoryList().addAll(helper().map(new CategoryMapper(), "SELECT * FROM event_category;"));
        return categoryList;
    }

    private static class CategoryMapper implements DataMapper<Category> {
        public Category create(ResultSet rs) throws SQLException {
            int id = rs.getInt("id");
            String name = rs.getString("name");
            return createCategory(id, name);
        }
    }


}
