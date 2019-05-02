package com.example.aniru.bottomnavigationbar;

public class User {

    private String email;
    private  Integer maxid;

    public Integer getMaxid() {
        return maxid;
    }

    public User(String email,Integer maxid) {
        this.maxid= maxid;
        this.email = email;

    }

    public String getEmail() {
        return email;
    }


}
