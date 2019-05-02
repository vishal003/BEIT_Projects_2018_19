package com.example.aniru.bottomnavigationbar;


import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;

import android.text.TextUtils;
import android.view.View;


import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import android.widget.EditText;
import android.widget.ProgressBar;

import android.widget.Toast;
import android.content.Intent;

import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;


import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;


public class SignupActivity extends AppCompatActivity {

    EditText  editTextEmail,  editTextPassword;
    long maxid = 1;

    ProgressBar progressBar;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_signup);
        editTextEmail =  findViewById(R.id.input_email);
        editTextPassword =  findViewById(R.id.input_password);
        progressBar =  findViewById(R.id.progressBar);



        findViewById(R.id.btn_signup).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                final FirebaseAuth mAuth = FirebaseAuth.getInstance();

                final String email = editTextEmail.getText().toString().trim();
                final String password = editTextPassword.getText().toString().trim();


                //first we will do the validations

                editTextEmail.requestFocus();


                if (TextUtils.isEmpty(email)) {
                    editTextEmail.setError("Please enter your email");
                    return;
                }

                if (!android.util.Patterns.EMAIL_ADDRESS.matcher(email).matches()) {
                    editTextEmail.setError("Enter a valid email");
                    editTextEmail.requestFocus();
                    return;
                }

                if (TextUtils.isEmpty(password)) {
                    editTextPassword.setError("Enter a password");
                    editTextPassword.requestFocus();
                    return;
                }



                mAuth.createUserWithEmailAndPassword(email, password).addOnCompleteListener(SignupActivity.this, new OnCompleteListener<AuthResult>()  {


                    @Override
                    public void onComplete(@NonNull Task<AuthResult> task) {
                        Toast.makeText(SignupActivity.this, "Sign Up Complete" + task.isSuccessful(), Toast.LENGTH_SHORT).show();
                        progressBar.setVisibility(View.GONE);
                        // If sign in fails, display a message to the user. If sign in succeeds
                        // the auth state listener will be notified and logic to handle the
                        // signed in user can be handled in the listener.
                        final FirebaseAuth mAuth = FirebaseAuth.getInstance();
                        if (!task.isSuccessful()) {
                            Toast.makeText(SignupActivity.this, "Authentication failed." + task.getException(),
                                    Toast.LENGTH_SHORT).show();
                        } else {

                            final FirebaseUser user = mAuth.getCurrentUser();

                            final FirebaseDatabase database = FirebaseDatabase.getInstance();
                            DatabaseReference Ref = database.getReference("/");

                            DatabaseReference logRef = Ref.child("User");

                            logRef.addValueEventListener(new ValueEventListener() {
                                @Override
                                public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                                    if(dataSnapshot.exists()){
                                        maxid=(dataSnapshot.getChildrenCount());
                                    }
                                }

                                @Override
                                public void onCancelled(@NonNull DatabaseError databaseError) {

                                }
                            });




                            user.sendEmailVerification()
                                    .addOnCompleteListener(new OnCompleteListener<Void>() {

                                        //final String username = editTextUsername.getText().toString().trim();
                                        final String email = editTextEmail.getText().toString().trim();
                                        final String password = editTextPassword.getText().toString().trim();
                                        //final String phone = editTextPhone.getText().toString().trim();

                                        @Override
                                        public void onComplete(@NonNull Task<Void> task) {
                                            if (task.isSuccessful()) {
                                                Toast.makeText(SignupActivity.this, "Email Verification Link Sent" + task.getException(),
                                                        Toast.LENGTH_SHORT).show();

                                                User user1 = new User(email, (int) maxid+1);

                                                FirebaseDatabase.getInstance().getReference("User").child(FirebaseAuth.getInstance().getCurrentUser().getUid()).setValue(user1).addOnCompleteListener(new OnCompleteListener<Void>() {
                                                    @Override
                                                    public void onComplete(@NonNull Task<Void> task) {
                                                        if(task.isSuccessful()){
                                                            Toast.makeText(SignupActivity.this, "User Created" + task.getException(),
                                                                    Toast.LENGTH_SHORT).show();
                                                        }
                                                        else {
                                                            Toast.makeText(SignupActivity.this, "User NOT Created" + task.getException(),
                                                                    Toast.LENGTH_SHORT).show();
                                                            return;
                                                        }
                                                    }
                                                });
                                                // email sent
                                                // after email is sent just logout the user and finish this activity
                                                FirebaseAuth.getInstance().signOut();
                                                startActivity(new Intent(SignupActivity.this, LoginActivity.class));
                                                finish();
                                            }
                                            else
                                            {
                                                // email not sent, so display message and restart the activity or do whatever you wish to do

                                                //restart this activity
                                                overridePendingTransition(0, 0);
                                                finish();
                                                overridePendingTransition(0, 0);
                                                startActivity(getIntent());

                                            }
                                        }
                                    });

                        }
                    }
                });


            }
        });


        findViewById(R.id.link_login).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //if user pressed on login
                //we will open the login screen
                finish();
                startActivity(new Intent(SignupActivity.this, LoginActivity.class));
            }
        });



    }
    @Override
    protected void onResume() {
        super.onResume();
        progressBar.setVisibility(View.GONE);
    }


}






