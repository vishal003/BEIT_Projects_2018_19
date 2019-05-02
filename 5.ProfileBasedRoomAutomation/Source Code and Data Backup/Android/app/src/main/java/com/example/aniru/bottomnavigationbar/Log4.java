package com.example.aniru.bottomnavigationbar;

import java.util.HashMap;
import java.util.Map;

public class Log4 {

    private String UID;
    private Integer Time, Light4;

    public Log4(){
        // Default constructor required for calls to DataSnapshot.getValue(Post.class)
    }

    public Log4(String UID, Integer Time,Integer Light4) {
        this.UID = UID;
        this.Time = Time;
        this.Light4=Light4;

    }

    public Map<String, Object> toMap() {
        HashMap<String, Object> result = new HashMap<>();

        result.put("UID",UID);
        result.put("Time",Time);
        result.put("Light4",Light4);

        return result;
    }

    public String getUID() {
        return UID;
    }

    public Integer getTime() {
        return Time;
    }

    public Integer getLight4() {
        return Light4;
    }
}

