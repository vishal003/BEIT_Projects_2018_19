package com.example.aniru.bottomnavigationbar;

import java.util.HashMap;
import java.util.Map;

public class Preference {


    private Integer Light1,Light2,Light3,Light4;
    private  String UID;

    public Preference(){
        // Default constructor required for calls to DataSnapshot.getValue(Post.class)
    }

    public Preference(String UID,Integer Light1,Integer Light2,Integer Light3,Integer Light4) {

        this.UID=UID;
        this.Light1=Light1;
        this.Light2=Light2;
        this.Light3=Light3;
        this.Light4=Light4;

    }

    public Map<String, Object> toMap() {
        HashMap<String, Object> result = new HashMap<>();
        result.put("UID",UID);
        result.put("Light 1",Light1);
        result.put("Light 2",Light2);
        result.put("Light 3",Light3);
        result.put("Light 4",Light4);

        return result;
    }


    public String getUID() {
        return UID;
    }

    public Integer getLight1() {
        return Light1;
    }
    public Integer getLight2() {
        return Light2;
    }
    public Integer getLight3() {
        return Light3;
    }
    public Integer getLight4() {
        return Light4;
    }
}
