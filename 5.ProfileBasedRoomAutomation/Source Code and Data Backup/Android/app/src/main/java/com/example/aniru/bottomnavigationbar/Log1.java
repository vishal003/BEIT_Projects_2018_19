package com.example.aniru.bottomnavigationbar;


import java.util.HashMap;
import java.util.Map;

public class Log1 {

    private String UID;
    private Integer Time, Light1;

    public Log1(){
        // Default constructor required for calls to DataSnapshot.getValue(Post.class)
    }

    public Log1(String UID, Integer Time,Integer Light1) {
        this.UID = UID;
        this.Time = Time;
        this.Light1=Light1;

    }

    public Map<String, Object> toMap() {
        HashMap<String, Object> result = new HashMap<>();

        result.put("UID",UID);
        result.put("Time",Time);
        result.put("Light1",Light1);

        return result;
    }

    public String getUID() {
        return UID;
    }

    public Integer getTime() {
        return Time;
    }

    public Integer getLight1() {
        return Light1;
    }
}

