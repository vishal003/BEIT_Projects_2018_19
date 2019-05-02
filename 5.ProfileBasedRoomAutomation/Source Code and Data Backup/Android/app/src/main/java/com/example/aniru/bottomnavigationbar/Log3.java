package com.example.aniru.bottomnavigationbar;

import java.util.HashMap;
import java.util.Map;

public class Log3 {

    private String UID;
    private Integer Time, Light3;

    public Log3(){
        // Default constructor required for calls to DataSnapshot.getValue(Post.class)
    }

    public Log3(String UID, Integer Time,Integer Light3) {
        this.UID = UID;
        this.Time = Time;
        this.Light3=Light3;

    }

    public Map<String, Object> toMap() {
        HashMap<String, Object> result = new HashMap<>();

        result.put("UID",UID);
        result.put("Time",Time);
        result.put("Light3",Light3);

        return result;
    }

    public String getUID() {
        return UID;
    }

    public Integer getTime() {
        return Time;
    }

    public Integer getLight3() {
        return Light3;
    }
}
