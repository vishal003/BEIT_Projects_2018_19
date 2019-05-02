package com.example.aniru.bottomnavigationbar;


import android.net.wifi.WifiManager;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatDelegate;
import android.text.format.Formatter;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.ProgressBar;
import android.widget.Toast;
import android.widget.Toolbar;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.Headers;
import okhttp3.Headers.Builder;
import okhttp3.HttpUrl;
import okhttp3.MediaType;
import okhttp3.MultipartBody;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;

import static android.content.Context.WIFI_SERVICE;
import static android.support.v4.content.ContextCompat.getSystemService;


/**
 * A simple {@link Fragment} subclass.
 */
public class ProfileFragment extends Fragment {


    private Button btnChangeEmail, btnChangePassword, btnSendResetEmail, btnRemoveUser,
            changeEmail, changePassword, sendEmail, remove, signOut;


    private EditText oldEmail, newEmail, password, newPassword;
    private ProgressBar progressBar;
    private FirebaseAuth.AuthStateListener authListener;
    private FirebaseAuth auth;
    private DatabaseReference mDatabase,Lights1,Lights2,Lights3,Lights4;
    int s,dayofweek, time;
    int userID;
    public ProfileFragment() {
        // Required empty public constructor
    }


    public static final MediaType JSON = MediaType.parse("application/json; charset=utf-8");


    public void restartApp() {
        Intent i = new Intent(getContext().getApplicationContext(),MainActivity.class);
        startActivity(i);

    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_profile, container, false);




    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {


       /* Toolbar toolbar = (Toolbar) getView().findViewById(R.id.toolbar);
        toolbar.setTitle(getString(R.string.app_name));
        setSupportActionBar(toolbar);*/

        //get firebase auth instance
        auth = FirebaseAuth.getInstance();
         Switch themeSwitch;
        //get current user
        final FirebaseUser user = FirebaseAuth.getInstance().getCurrentUser();
        // FETCH TIME
        SimpleDateFormat sdf = new SimpleDateFormat("HHmm");
        s = Integer.parseInt(sdf.format(new Date()).replace(":"," "));
        
        if (s == 900 || s <= 1000  )
        {
           //s = 900;
           time=1;
        }
        else {
            if (s == 1000 || s <= 1100  )
            {
                //s = 1000;
                time=2;
            }
            else{
                if (s == 1100 || s <= 1200  )
                {
                   // s = 1100;
                    time=3;
                }
                else{
                    if(s == 1200 || s <= 1300  )
                    {
                        //s = 1200;
                        time=4;
                    }
                    else{
                        if(s == 1300 || s <= 1400  )
                        {
                           // s = 1300;
                            time=5;
                        }
                        else {
                            if(s == 1300 || s <= 1400  )
                            {
                               // s = 1300;
                                time=6;
                            }
                            else {
                                if(s == 1400 || s <= 1500  )
                                {
                                    //s = 1400;
                                    time=7;
                                }
                                else {
                                    if(s == 1500 || s <= 1600  )
                                    {
                                       // s = 1500;
                                        time=8;
                                    }
                                    else {
                                        if(s == 1600 || s <= 1700  )
                                        {
                                           // s = 1700;
                                            time=9;
                                        }
                                        else {
                                            if(s <900 || s > 1700  )
                                            {

                                                time=0;
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        Calendar calendar = Calendar.getInstance();
        dayofweek = calendar.get(Calendar.DAY_OF_WEEK);

        switch (dayofweek) {

            case Calendar.MONDAY:
                // Current day is Monday
                dayofweek = 1;
                break;
            case Calendar.TUESDAY:
                dayofweek = 2;
                break;
            case Calendar.WEDNESDAY:
                dayofweek = 3;
                break;
            case Calendar.THURSDAY:
                dayofweek = 4;
                break;
            case Calendar.FRIDAY:
                dayofweek = 5;
                break;
            case Calendar.SATURDAY:
                dayofweek = 6;
                break;

                default:
                dayofweek = 0;
        }

        //get User ID
        String UID = FirebaseAuth.getInstance().getCurrentUser().getUid();
        mDatabase= FirebaseDatabase.getInstance().getReference().child("User").child(UID);
        mDatabase.keepSynced(true);
        mDatabase.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                dataSnapshot.getChildren();

                userID = dataSnapshot.child("maxid").getValue(Integer.class);
                FirebaseDatabase database = FirebaseDatabase.getInstance();
                DatabaseReference myRef2 = database.getReference("userid");
                myRef2.setValue(userID);

            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {

            }
        });



        //ML ACT

        FirebaseDatabase database = FirebaseDatabase.getInstance();
        DatabaseReference myRef1 = database.getReference("time");
        myRef1.setValue(time);



        DatabaseReference myRef3 = database.getReference("day");
        myRef3.setValue(dayofweek);


/*



    /*    //THEME SWITCH
        if(AppCompatDelegate.getDefaultNightMode()==AppCompatDelegate.MODE_NIGHT_YES){
            getActivity().setTheme(R.style.DarkTheme);
        }
        else getActivity().setTheme(R.style.AppTheme);

        themeSwitch=(Switch)getView().findViewById(R.id.themeSwitch);
        if(AppCompatDelegate.getDefaultNightMode()==AppCompatDelegate.MODE_NIGHT_YES){
            themeSwitch.setChecked(true);
        }

        themeSwitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
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
        });
*/


        authListener = new FirebaseAuth.AuthStateListener() {
            @Override
            public void onAuthStateChanged(@NonNull FirebaseAuth firebaseAuth) {
                FirebaseUser user = firebaseAuth.getCurrentUser();
                if (user == null) {
                    // user auth state is changed - user is null
                    // launch login activity
                    startActivity(new Intent(getActivity(), LoginActivity.class));
                    //finish();
                }
            }
        };

        btnChangeEmail = (Button) getView().findViewById(R.id.change_email_button);
        btnChangePassword = (Button) getView().findViewById(R.id.change_password_button);
        btnSendResetEmail = (Button) getView().findViewById(R.id.sending_pass_reset_button);
        btnRemoveUser = (Button) getView().findViewById(R.id.remove_user_button);
        changeEmail = (Button) getView().findViewById(R.id.changeEmail);
        changePassword = (Button) getView().findViewById(R.id.changePass);
        sendEmail = (Button) getView().findViewById(R.id.send);
        remove = (Button) getView().findViewById(R.id.remove);
        signOut = (Button) getView().findViewById(R.id.sign_out);

        oldEmail = (EditText) getView().findViewById(R.id.old_email);
        newEmail = (EditText) getView().findViewById(R.id.new_email);
        password = (EditText) getView().findViewById(R.id.password);
        newPassword = (EditText) getView().findViewById(R.id.newPassword);

        oldEmail.setVisibility(View.GONE);
        newEmail.setVisibility(View.GONE);
        password.setVisibility(View.GONE);
        newPassword.setVisibility(View.GONE);
        changeEmail.setVisibility(View.GONE);
        changePassword.setVisibility(View.GONE);
        sendEmail.setVisibility(View.GONE);
        remove.setVisibility(View.GONE);

        progressBar = (ProgressBar) getView().findViewById(R.id.progressBar);

        if (progressBar != null) {
            progressBar.setVisibility(View.GONE);
        }

        btnChangeEmail.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                oldEmail.setVisibility(View.GONE);
                newEmail.setVisibility(View.VISIBLE);
                password.setVisibility(View.GONE);
                newPassword.setVisibility(View.GONE);
                changeEmail.setVisibility(View.VISIBLE);
                changePassword.setVisibility(View.GONE);
                sendEmail.setVisibility(View.GONE);
                remove.setVisibility(View.GONE);
            }
        });

        changeEmail.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                progressBar.setVisibility(View.VISIBLE);
                if (user != null && !newEmail.getText().toString().trim().equals("")) {
                    user.updateEmail(newEmail.getText().toString().trim())
                            .addOnCompleteListener(new OnCompleteListener<Void>() {
                                @Override
                                public void onComplete(@NonNull Task<Void> task) {
                                    if (task.isSuccessful()) {
                                        Toast.makeText(getActivity(), "Email address is updated. Please sign in with new email id!", Toast.LENGTH_LONG).show();
                                        signOut();
                                        progressBar.setVisibility(View.GONE);
                                    } else {
                                        Toast.makeText(getActivity(), "Failed to update email!", Toast.LENGTH_LONG).show();
                                        progressBar.setVisibility(View.GONE);
                                    }
                                }
                            });
                } else if (newEmail.getText().toString().trim().equals("")) {
                    newEmail.setError("Enter email");
                    progressBar.setVisibility(View.GONE);
                }
            }
        });

        btnChangePassword.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                oldEmail.setVisibility(View.GONE);
                newEmail.setVisibility(View.GONE);
                password.setVisibility(View.GONE);
                newPassword.setVisibility(View.VISIBLE);
                changeEmail.setVisibility(View.GONE);
                changePassword.setVisibility(View.VISIBLE);
                sendEmail.setVisibility(View.GONE);
                remove.setVisibility(View.GONE);
            }
        });

        changePassword.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                progressBar.setVisibility(View.VISIBLE);
                if (user != null && !newPassword.getText().toString().trim().equals("")) {
                    if (newPassword.getText().toString().trim().length() < 6) {
                        newPassword.setError("Password too short, enter minimum 6 characters");
                        progressBar.setVisibility(View.GONE);
                    } else {
                        user.updatePassword(newPassword.getText().toString().trim())
                                .addOnCompleteListener(new OnCompleteListener<Void>() {
                                    @Override
                                    public void onComplete(@NonNull Task<Void> task) {
                                        if (task.isSuccessful()) {
                                            Toast.makeText(getActivity(), "Password is updated, sign in with new password!", Toast.LENGTH_SHORT).show();
                                            signOut();
                                            progressBar.setVisibility(View.GONE);
                                        } else {
                                            Toast.makeText(getActivity(), "Failed to update password!", Toast.LENGTH_SHORT).show();
                                            progressBar.setVisibility(View.GONE);
                                        }
                                    }
                                });
                    }
                } else if (newPassword.getText().toString().trim().equals("")) {
                    newPassword.setError("Enter password");
                    progressBar.setVisibility(View.GONE);
                }
            }
        });

        btnSendResetEmail.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                oldEmail.setVisibility(View.VISIBLE);
                newEmail.setVisibility(View.GONE);
                password.setVisibility(View.GONE);
                newPassword.setVisibility(View.GONE);
                changeEmail.setVisibility(View.GONE);
                changePassword.setVisibility(View.GONE);
                sendEmail.setVisibility(View.VISIBLE);
                remove.setVisibility(View.GONE);
            }
        });

        sendEmail.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                progressBar.setVisibility(View.VISIBLE);
                if (!oldEmail.getText().toString().trim().equals("")) {
                    auth.sendPasswordResetEmail(oldEmail.getText().toString().trim())
                            .addOnCompleteListener(new OnCompleteListener<Void>() {
                                @Override
                                public void onComplete(@NonNull Task<Void> task) {
                                    if (task.isSuccessful()) {
                                        Toast.makeText(getActivity(), "Reset password email is sent!", Toast.LENGTH_SHORT).show();
                                        progressBar.setVisibility(View.GONE);
                                    } else {
                                        Toast.makeText(getActivity(), "Failed to send reset email!", Toast.LENGTH_SHORT).show();
                                        progressBar.setVisibility(View.GONE);
                                    }
                                }
                            });
                } else {
                    oldEmail.setError("Enter email");
                    progressBar.setVisibility(View.GONE);
                }
            }
        });

        btnRemoveUser.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                progressBar.setVisibility(View.VISIBLE);
                if (user != null) {
                    user.delete()
                            .addOnCompleteListener(new OnCompleteListener<Void>() {
                                @Override
                                public void onComplete(@NonNull Task<Void> task) {
                                    if (task.isSuccessful()) {
                                        Toast.makeText(getActivity(), "Your profile is deleted:( Create a account now!", Toast.LENGTH_SHORT).show();
                                        startActivity(new Intent(getActivity(), SignupActivity.class));
                                        //finish();
                                        progressBar.setVisibility(View.GONE);
                                    } else {
                                        Toast.makeText(getActivity(), "Failed to delete your account!", Toast.LENGTH_SHORT).show();
                                        progressBar.setVisibility(View.GONE);
                                    }
                                }
                            });
                }
            }
        });

        signOut.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                FirebaseDatabase database = FirebaseDatabase.getInstance();
                DatabaseReference myRef1 = database.getReference("Light1");
                myRef1.setValue(0);

                DatabaseReference myRef2 = database.getReference("Light2");
                myRef2.setValue(0);

                DatabaseReference myRef3 = database.getReference("Light3");
                myRef3.setValue(0);

                DatabaseReference myRef4 = database.getReference("Light4");
                myRef4.setValue(0);

                DatabaseReference myRef5 = database.getReference("time");
                myRef5.setValue(0);

                DatabaseReference myRef6 = database.getReference("userid");
                myRef6.setValue(0);

                DatabaseReference myRef7 = database.getReference("day");
                myRef7.setValue(0);

                DatabaseReference myRef8 = database.getReference("override");
                myRef8.setValue(1);

                signOut();
            }
        });

    }

    //sign out method
    public void signOut() {
        auth.signOut();
    }

    @Override
    public void onResume() {
        super.onResume();
        progressBar.setVisibility(View.GONE);
    }

    @Override
    public void onStart() {
        super.onStart();
        auth.addAuthStateListener(authListener);
    }

    @Override
    public void onStop() {
        super.onStop();
        if (authListener != null) {
            auth.removeAuthStateListener(authListener);
        }
    }


}
