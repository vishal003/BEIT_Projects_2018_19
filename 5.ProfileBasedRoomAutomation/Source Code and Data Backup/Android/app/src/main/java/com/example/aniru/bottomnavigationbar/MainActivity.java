  package com.example.aniru.bottomnavigationbar;

import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.app.AppCompatDelegate;
import android.view.MenuItem;
import android.view.Window;
import android.view.WindowManager;
import android.widget.CompoundButton;
import android.widget.FrameLayout;
import android.widget.Switch;

  public class MainActivity extends AppCompatActivity {
    //Navigation Bar variable
    private BottomNavigationView nMainNav;
    // Frame Variable
    private FrameLayout nMainFrame;
    //Fragment Variables
    private HomeFragment homeFragment;
    private PresetsFragment presetsFragment;
    private AnalyticsFragment analyticsFragment;
    private ProfileFragment profileFragment;
    //Switch variable
    private Switch themeSwitch;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,   WindowManager.LayoutParams.FLAG_FULLSCREEN);
        setContentView(R.layout.activity_main);


        nMainNav = (BottomNavigationView) findViewById(R.id.main_nav);
        nMainFrame = (FrameLayout) findViewById(R.id.main_frame);
        homeFragment = new HomeFragment();
        presetsFragment =new PresetsFragment();
        analyticsFragment = new AnalyticsFragment();
        profileFragment = new ProfileFragment();
/*
        if(AppCompatDelegate.getDefaultNightMode()==AppCompatDelegate.MODE_NIGHT_YES){
            setTheme(R.style.DarkTheme);
        }
        else setTheme(R.style.AppTheme);

        themeSwitch=(Switch)findViewById(R.id.themeSwitch);
        if(AppCompatDelegate.getDefaultNightMode()==AppCompatDelegate.MODE_NIGHT_YES){
            themeSwitch.setChecked(true);
        }*/

       /* themeSwitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if(isChecked){
                    AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_YES);
                    restartApp();
                }
                else {
                    AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_NO);
                    restartApp();
                }

            }
        });*/

        setFragment();

        nMainNav.setOnNavigationItemSelectedListener(new BottomNavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem menuItem) {

                switch(menuItem.getItemId()) {


                    case R.id.nav_home:
                        setFragment(homeFragment);
                        return true;

                    case R.id.nav_presets:
                        setFragment(presetsFragment);
                        return true;
/*
                    case R.id.nav_analytics:
                        setFragment(analyticsFragment);
                        return true;*/

                    case R.id.nav_profile:
                        setFragment(profileFragment);
                        return true;

                    default:
                        return true;


                }
            }



            private void setFragment(Fragment fragment) {

                FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
                fragmentTransaction.replace(R.id.main_frame, fragment);
                fragmentTransaction.commitAllowingStateLoss();

            }


        });
    }

    /*public void restartApp(){
        Intent i = new Intent(getApplicationContext(),MainActivity.class);
        startActivity(i);
        finish();
    }*/

    private void setFragment() {
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.main_frame,profileFragment);
        fragmentTransaction.commitAllowingStateLoss();
    }




}
